// /Harmony.Abstractions/Contracts/IDiagnosticSink.cs

// -------------------------------------------------------------------------------------------------
using System.Text.Json;

namespace Harmony.Tooling.Contracts;

using Harmony.Tooling.Models;

/// <summary>
/// Diagnostic sink for tool invocations. Hosts can implement this to receive detailed information
/// about tool usage, including inputs, outputs, errors, and performance metrics. This allows for 
/// monitoring, logging, and analysis of tool interactions within the system.
/// </summary>
public interface IDiagnosticSink
{
   void OnToolStart(ToolInvocationStart start);
   void OnToolEnd(ToolInvocationEnd end);
}

/// <summary>
/// Tool invocation start information, including tool name, version, timestamp, session ID, 
/// message index, and inputs.
/// </summary>
public sealed class ToolInvocationStart
{
   public required string Tool { get; init; }
   public required string Version { get; init; }
   public required DateTimeOffset Timestamp { get; init; }
   public string? SessionId { get; init; }
   public int? MessageIndex { get; init; }
   public JsonElement Inputs { get; init; }
}

/// <summary>
/// Tool invocation end information, including tool name, version, timestamp, elapsed time, success
/// status, outputs, errors, cache key, and flags for quick inspection.
/// </summary>
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
