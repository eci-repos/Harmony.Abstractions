
// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Discovery;

/// <summary>
/// Tool availability interface for hosts to indicate which tools (e.g., "web.httpGet") are
/// available for invocation.
/// </summary>
public interface IToolAvailability
{
   /// <summary>
   /// Returns true if the recipient (e.g., "web.httpGet") is callable in this host.
   /// Must be side‑effect free and fast (ideally O(1)).
   /// </summary>
   Task<bool> IsAvailableAsync(string recipient, CancellationToken ct = default);

   /// <summary>
   /// Optional: enumerate known tools. May be empty if host cannot enumerate.
   /// </summary>
   Task<IReadOnlyCollection<string>> ListAvailableAsync(CancellationToken ct = default);

   /// <summary>
   /// Optional: get a descriptor for the recipient if available (flags, provider, etc.).
   /// Enables richer preflight without binding to a registry.
   /// </summary>
   Task<Models.ToolDescriptor?> DescribeAsync(string recipient, CancellationToken ct = default);
}
