// /Harmony.Abstractions/Models/ToolResult.cs
using System.Text.Json;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Models;

/// <summary>Result envelope to normalize success/error outcomes and support replay.</summary>
public sealed class ToolResult
{
   public required bool Ok { get; init; }
   public JsonElement Data { get; init; }        // success payload (default = default(JsonElement))
   public ToolError? Error { get; init; }        // present if Ok=false
   public string? CacheKey { get; init; }        // for artifact reuse if Replayable
   public TimeSpan Elapsed { get; init; }        // timing for diagnostics
}
