
// /Harmony.Abstractions/Harmony.Tooling/Helpers/ToolName.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Helpers;

public static class ToolName
{
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

