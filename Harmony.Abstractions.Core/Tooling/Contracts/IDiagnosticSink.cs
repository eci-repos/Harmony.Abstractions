// /Harmony.Abstractions/Contracts/IDiagnosticSink.cs

// -------------------------------------------------------------------------------------------------
using System.Text.Json;

namespace Harmony.Abstractions.Contracts;

using Harmony.Abstractions.Models;

public interface IDiagnosticSink
{
   void OnToolStart(ToolInvocationStart start);
   void OnToolEnd(ToolInvocationEnd end);
}

public sealed class ToolInvocationStart
{
   public required string Tool { get; init; }
   public required string Version { get; init; }
   public required DateTimeOffset Timestamp { get; init; }
   public string? SessionId { get; init; }
   public int? MessageIndex { get; init; }
   public JsonElement Inputs { get; init; }
}

public sealed class ToolInvocationEnd
{
   public required string Tool { get; init; }
   public required string Version { get; init; }
   public required DateTimeOffset Timestamp { get; init; }
   public required TimeSpan Elapsed { get; init; }
   public bool Ok { get; init; }
   public JsonElement Data { get; init; }
   public ToolError? Error { get; init; }
   public string? CacheKey { get; init; }
   public string[]? Flags { get; init; } // eg ["Replayable","RequiresNetwork"] for quick inspection
}
