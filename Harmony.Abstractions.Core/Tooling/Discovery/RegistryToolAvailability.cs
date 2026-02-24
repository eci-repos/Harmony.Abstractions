
// Harmony.Abstractions  →  Harmony.Tooling.Discovery
using Harmony.Tooling.Contracts;
using Harmony.Tooling.Models;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Discovery;

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

   private string Map(string name)
       => (_aliases is not null && _aliases.TryGetValue(name, out var mapped)) ? mapped : name;
}
