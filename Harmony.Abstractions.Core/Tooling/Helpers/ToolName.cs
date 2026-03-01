
// /Harmony.Abstractions/Harmony.Tooling/Helpers/ToolName.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Helpers;

/// <summary>
/// ToolName is a helper class for parsing and combining tool names in the format
/// "Namespace.FunctionName". It provides methods to extract the namespace and function name 
/// from a given string, as well as to combine them into a single string. This is useful for 
/// tools that need to identify and work with specific functions within a namespace. 
/// </summary>
public static class ToolName
{
   /// <summary>
   /// Try to parse a recipient string into its namespace and function name components. 
   /// The recipient should be in the format "Namespace.FunctionName". If the parsing is
   /// successful, the method returns true and outputs the namespace and function name. 
   /// If the parsing fails (e.g., if the recipient is null, empty, or does not contain a dot),
   /// the method returns false and outputs empty strings for both the namespace and 
   /// function name. 
   /// </summary>
   /// <param name="recipient"></param>
   /// <param name="ns"></param>
   /// <param name="fn"></param>
   /// <returns></returns>
   public static bool TryParse(string recipient, out string ns, out string fn)
   {
      ns = fn = string.Empty;
      if (string.IsNullOrWhiteSpace(recipient)) return false;
      var dot = recipient.LastIndexOf('.');
      if (dot <= 0 || dot == recipient.Length - 1) return false;
      ns = recipient[..dot]; fn = recipient[(dot + 1)..]; return true;
   }

   public static string Combine(string ns, string fn) => $"{ns}.{fn}";
}

