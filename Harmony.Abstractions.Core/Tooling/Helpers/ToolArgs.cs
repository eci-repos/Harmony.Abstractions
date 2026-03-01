
// /Harmony.Abstractions/Harmony.Tooling/Helpers/ToolArgs.cs
using System.Text.Json;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Helpers;

/// <summary>
/// ToolArgs is a helper class for converting objects and dictionaries into JsonDocument instances.
/// This is useful for tools that need to work with JSON data, allowing them to easily serialize 
/// objects and dictionaries into a format that can be consumed by other components or services. 
/// The class provides two static methods - FromObject and FromDictionary - which take an object 
/// or a dictionary as input and return a JsonDocument representing the serialized data.
/// This simplifies the process of preparing data for tools that require JSON input.  
/// </summary>
public static class ToolArgs
{
   /// <summary>
   /// FromObject takes an object as input and serializes it into a JsonDocument. This method uses 
   /// the System.Text.Json.JsonSerializer to convert the object into a JSON string, which is then 
   /// parsed into a JsonDocument. This allows tools to easily convert complex objects into a JSON 
   /// format that can be consumed by other components or services. The method returns a 
   /// JsonDocument representing the serialized data of the input object. 
   /// </summary>
   /// <param name="value"></param>
   /// <returns></returns>
   public static JsonDocument FromObject(object? value) =>
       JsonDocument.Parse(System.Text.Json.JsonSerializer.Serialize(value));

   /// <summary>
   /// FromDictionary takes a dictionary of string keys and object values as input and serializes 
   /// it into a JsonDocument. Similar to FromObject, this method uses the 
   /// System.Text.Json.JsonSerializer to convert the dictionary into a JSON string, which is 
   /// then parsed into a JsonDocument. This is particularly useful for tools that need to work
   /// with key-value pairs, allowing them to easily convert a dictionary into a JSON format.
   /// The method returns a JsonDocument representing the serialized data of the input dictionary. 
   /// </summary>
   /// <param name="args"></param>
   /// <returns></returns>
   public static JsonDocument FromDictionary(IReadOnlyDictionary<string, object?> args) =>
       JsonDocument.Parse(System.Text.Json.JsonSerializer.Serialize(args));
}
