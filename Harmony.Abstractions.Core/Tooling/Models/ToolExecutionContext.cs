// /Harmony.Abstractions/Models/ToolExecutionContext.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Models;

using Harmony.Tooling.Contracts;

/// <summary>
/// Optional context for a tool invocation; host supplies correlation and services.
/// </summary>
public sealed class ToolExecutionContext
{
   /// <summary>Logical session identifier (if any) for diagnostics/audit.</summary>
   public string? SessionId { get; init; }

   /// <summary>Envelope/message index (HRF) for step-level tracing.</summary>
   public int? MessageIndex { get; init; }

   /// <summary>Execution mode hint ("strict", "replay-allowed"); policy is host-side.</summary>
   public string? Mode { get; init; }

   /// <summary>Redactor to apply before emitting inputs/outputs to diagnostics/artifacts.</summary>
   public IRedactor? Redactor { get; init; }

   /// <summary>Diagnostics sink for start/end events.</summary>
   public IDiagnosticSink? Diagnostics { get; init; }

   /// <summary>Arbitrary correlation properties (e.g., request IDs).</summary>
   public IReadOnlyDictionary<string, string>? Correlation { get; init; }
}
