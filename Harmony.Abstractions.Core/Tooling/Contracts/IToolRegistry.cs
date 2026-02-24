// /Harmony.Abstractions/Contracts/IToolRegistry.cs

using Harmony.Tooling.Models;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Contracts;

public interface IToolRegistry
{
   void Register(ITool tool);
   ITool? Resolve(string name);
   IEnumerable<ToolDescriptor> List();
}
