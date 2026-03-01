// /Harmony.Abstractions/Harmony.Tooling/Preflight/IToolDependencyExtractor.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Preflight;

public interface IToolDependencyExtractor
{
   /// <summary>
   /// Extract unique tool recipients (e.g., "plugin.function") from a format-specific 
   /// script object.
   /// </summary>
   Task<IReadOnlyCollection<string>> ExtractRecipientsAsync(
      object script, CancellationToken ct = default);
}
