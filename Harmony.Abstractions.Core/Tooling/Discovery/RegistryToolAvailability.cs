
// Harmony.Abstractions  →  Harmony.Tooling.Discovery
using Harmony.Tooling.Contracts;
using Harmony.Tooling.Models;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Discovery;

/// <summary>
/// Registry-based tool availability that checks the provided IToolRegistry for tool availability. 
/// This is a common implementation that can be used in production, as it relies on a registry of
/// tools that can be configured and managed separately. It also supports optional aliases for 
/// tool names, allowing for more flexible tool identification.
/// </summary>
public sealed class RegistryToolAvailability : IToolAvailability
{
   private readonly IToolRegistry _registry;
   private readonly IReadOnlyDictionary<string, string>? _aliases;

   public RegistryToolAvailability(IToolRegistry registry,
                                   IReadOnlyDictionary<string, string>? aliases = null)
       => _registry = registry ?? throw new ArgumentNullException(nameof(registry));

   public Task<bool> IsAvailableAsync(string recipient, CancellationToken ct = default)
       => Task.FromResult(_registry.Resolve(Map(recipient)) is not null);

   public Task<IReadOnlyCollection<string>> ListAvailableAsync(CancellationToken ct = default)
       => Task.FromResult(
          (IReadOnlyCollection<string>)_registry.List().Select(d => d.Name).ToArray());

   public Task<ToolDescriptor?> DescribeAsync(string recipient, CancellationToken ct = default)
       => Task.FromResult(_registry.List().FirstOrDefault(d =>
              d.Name.Equals(Map(recipient), StringComparison.OrdinalIgnoreCase)));

   /// <summary>
   /// Maps the given recipient name to a tool name using the aliases dictionary, if provided. 
   /// If no alias is found, it returns the original name. This allows for flexible tool 
   /// identification, where a recipient can be mapped to a different tool name in the registry, 
   /// enabling scenarios where multiple recipients can refer to the same tool or where recipient
   /// names can be more user-friendly while still resolving to the correct tool in the registry. 
   /// </summary>
   /// <param name="name"></param>
   /// <returns></returns>
   private string Map(string name)
       => (_aliases is not null && _aliases.TryGetValue(name, out var mapped)) ? mapped : name;
}
