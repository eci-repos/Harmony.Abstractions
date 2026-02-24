// /Harmony.Abstractions/Contracts/ITool.cs
using System.Text.Json;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Contracts;

using Harmony.Tooling.Models;

public interface ITool
{
   /// <summary>Canonical tool name, e.g., "web.httpGet".</summary>
   string Name { get; }

   /// <summary>SemVer version.</summary>
   string Version { get; }

   /// <summary>Descriptor (static) for discovery/preflight.</summary>
   ToolDescriptor Descriptor { get; }

   /// <summary>
   /// Execute the tool with JSON input. Tools should be pure with respect to input,
   /// except when marked Mutating. Hosts supply context for diagnostics/redaction.
   /// </summary>
   /// <param name="input">JSON input (object or primitive as appropriate).</param>
   /// <param name="context">Execution context (optional).</param>
   /// <param name="ct">Cancellation token.</param>
   /// <returns>Structured ToolResult with data or error.</returns>
   Task<ToolResult> ExecuteAsync(
      JsonDocument input, ToolExecutionContext? context = null, CancellationToken ct = default);
}
