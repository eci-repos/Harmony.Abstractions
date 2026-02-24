
// /Harmony.Abstractions/Harmony.Tooling/Execution/IToolInvoker.cs
using System.Text.Json;
using Harmony.Tooling.Models;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Execution;

public interface IToolInvoker
{
   Task<ToolResult> InvokeAsync(string recipient, JsonDocument input, ToolExecutionContext? 
      ctx = null, CancellationToken ct = default);
}
