// Harmony.Tooling.Preflight/ToolPreflightAnalyzer.cs
using Harmony.Tooling.Discovery;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Preflight;

/// <summary>
/// Tool preflight analyzer that checks availability of required tools for a given set of recipients 
/// and mode.
/// </summary>
public sealed class ToolPreflightAnalyzer : IToolPreflightAnalyzer
{
   private readonly IToolAvailability _availability;

   public ToolPreflightAnalyzer(IToolAvailability availability)
       => _availability = availability ?? throw new ArgumentNullException(nameof(availability));

   public async Task<PreflightReport> AnalyzeAsync(
      IEnumerable<string> recipients, string mode, CancellationToken ct = default)
   {
      if (recipients is null) throw new ArgumentNullException(nameof(recipients));

      var required = recipients.Where(s => !string.IsNullOrWhiteSpace(s))
                               .Select(s => s.Trim())
                               .Distinct(StringComparer.OrdinalIgnoreCase)
                               .ToArray();

      var available = new List<string>();
      var missing = new List<string>();

      foreach (var r in required)
      {
         if (await _availability.IsAvailableAsync(r, ct).ConfigureAwait(false))
            available.Add(r);
         else
            missing.Add(r);
      }

      return new PreflightReport
      {
         RequiredTools = required,
         Available = available.OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToArray(),
         Missing = missing.OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToArray(),
         Mode = mode
      };
   }
}
