// /Harmony.Abstractions/Contracts/IToolRegistry.cs

using Harmony.Tooling.Models;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Contracts;

/// <summary>
/// Tool registry interface for managing and resolving tools within the Harmony framework. 
/// This interface allows for the registration of tools, resolution of tools by name, and listing
/// of available tools. It serves as a central point for tool management, enabling dynamic 
/// discovery and usage of tools in various contexts within the Harmony ecosystem.
/// </summary>
public interface IToolRegistry
{
   void Register(ITool tool);
   ITool? Resolve(string name);
   IEnumerable<ToolDescriptor> List();
}
