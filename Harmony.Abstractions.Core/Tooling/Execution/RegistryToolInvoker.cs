
// /Harmony.Abstractions/Harmony.Tooling/Execution/RegistryToolInvoker.cs
using System.Text.Json;
using Harmony.Tooling.Contracts;
using Harmony.Tooling.Models;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Execution;

public sealed class RegistryToolInvoker : IToolInvoker
{
   private readonly IToolRegistry _registry;

   public RegistryToolInvoker(IToolRegistry registry) => _registry = registry;

   public async Task<ToolResult> InvokeAsync(string recipient, JsonDocument input, 
      ToolExecutionContext? ctx = null, CancellationToken ct = default)
   {
      var tool = _registry.Resolve(recipient);
      if (tool is null)
      {
         var err = new ToolError 
         { 
            Code = KnownErrorCodes.DependencyMissing, Message = $"Tool '{recipient}' not found." 
         };

         ctx?.Diagnostics?.OnToolEnd(new Contracts.ToolInvocationEnd
         {
            Tool = recipient,
            Version = "unknown",
            Timestamp = DateTimeOffset.UtcNow,
            Elapsed = TimeSpan.Zero,
            Ok = false,
            Error = err,
            Data = default
         });
         return new ToolResult { Ok = false, Error = err };
      }

      return await tool.ExecuteAsync(input, ctx, ct).ConfigureAwait(false);
   }
}
