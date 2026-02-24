// /Harmony.Abstractions/Models/ToolDescriptor.cs
using System.Text.Json.Serialization;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Models;

/// <summary>
/// Describes a tool for discovery, preflight, and diagnostics.
/// </summary>
public sealed class ToolDescriptor
{
   public required string Name { get; init; }          // canonical: "category.toolName"

   public required string Version { get; init; }       // SemVer
   public ToolFlags Flags { get; init; } = ToolFlags.None;

   /// <summary>Provider short label, e.g., "Graph", "OneDrive", "Qdrant", "HttpClient".</summary>
   public string? Provider { get; init; }

   /// <summary>Optional allow-list constraints (domains, roots, etc.) for governance.</summary>
   public string[]? AllowList { get; init; }

   /// <summary>Optional JSON Schema for inputs (stringified). Host may expose to clients.</summary>
   public string? InputJsonSchema { get; init; }

   /// <summary>Optional JSON Schema for outputs (stringified).</summary>
   public string? OutputJsonSchema { get; init; }

   /// <summary>Hints for deterministic replay/freshness; policy is host-driven.</summary>
   public DeterminismHints? Hints { get; init; }

   /// <summary>Arbitrary metadata (stable, public) for discovery UIs.</summary>
   public Dictionary<string, string>? Metadata { get; init; }

   /// <summary>Arbitrary metadata (private) for host/tooling diagnostics, not for discovery UIs.
   /// </summary>
   public Dictionary<string, string>? Tags { get; init; }
}
