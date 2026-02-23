
// /Harmony.Abstractions/Infrastructure/InMemoryToolRegistry.cs

// -------------------------------------------------------------------------------------------------
using Harmony.Abstractions.Contracts;
using Harmony.Abstractions.Models;

namespace Harmony.Abstractions.Infrastructure;

public sealed class InMemoryToolRegistry : IToolRegistry
{
   private readonly Dictionary<string, ITool> _byName = new(StringComparer.OrdinalIgnoreCase);

   public void Register(ITool tool) => _byName[tool.Name] = tool;

   public ITool? Resolve(string name) => _byName.TryGetValue(name, out var t) ? t : null;

   public IEnumerable<ToolDescriptor> List() => _byName.Values.Select(v => v.Descriptor);
}
