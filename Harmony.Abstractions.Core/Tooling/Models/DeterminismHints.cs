
// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Models;

/// <summary>
/// Optional hints to support deterministic replay and freshness policies.
/// Policy enforcement lives outside tools (e.g., MCP); tools only declare hints.
/// </summary>
public sealed class DeterminismHints
{
   /// <summary>Advisory cache key (e.g., URL or input fingerprint) for artifact reuse.</summary>
   public string? CacheKey { get; init; }

   /// <summary>Optional time-to-live (seconds) for freshness, if host supports it.</summary>
   public int? TtlSeconds { get; init; }

   /// <summary>
   /// Optional stable input hash (e.g., SHA256 over canonical inputs) to key artifacts.
   /// Hosts may compute this; tools can also supply if readily available.
   /// </summary>
   public string? InputHash { get; init; }
}
