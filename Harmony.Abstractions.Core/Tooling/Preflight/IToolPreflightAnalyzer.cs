// Harmony.Tooling.Preflight/IToolPreflightAnalyzer.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Preflight;

public interface IToolPreflightAnalyzer
{
   Task<PreflightReport> AnalyzeAsync(
       IEnumerable<string> recipients,
       string mode,                       // "strict" | "replay-allowed"
       CancellationToken ct = default);
}
