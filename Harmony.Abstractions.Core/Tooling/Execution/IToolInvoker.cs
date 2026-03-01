
// /Harmony.Abstractions/Harmony.Tooling/Execution/IToolInvoker.cs
using System.Text.Json;
using Harmony.Tooling.Models;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Execution;

/// <summary>
/// Tool invoker interface for executing tools with given input and context. 
/// </summary>
public interface IToolInvoker
{
   /// <summary>
   /// Invokes a tool for the specified recipient with the provided input and execution context. 
   /// </summary>
   /// <param name="recipient"></param>
   /// <param name="input"></param>
   /// <param name="ctx"></param>
   /// <param name="ct"></param>
   /// <returns></returns>
   Task<ToolResult> InvokeAsync(string recipient, JsonDocument input, ToolExecutionContext? 
      ctx = null, CancellationToken ct = default);
}
