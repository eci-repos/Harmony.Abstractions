// /Harmony.Abstractions/Contracts/IToolRegistry.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Abstractions.Contracts;

using Harmony.Abstractions.Models;

public interface IToolRegistry
{
   void Register(ITool tool);
   ITool? Resolve(string name);
   IEnumerable<ToolDescriptor> List();
}
