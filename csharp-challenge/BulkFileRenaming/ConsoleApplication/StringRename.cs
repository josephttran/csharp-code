using System.Globalization;
using System.Text.RegularExpressions;

namespace ConsoleApplication
{
    public class StringRename
    {
        public static string ToTitleCase(string text)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            string titleCaseText = textInfo.ToTitleCase(text.ToLower());

            return titleCaseText;
        }

        public static string ReplaceExact(string text, string search, string replaceWith)
        {
            string pattern = $"\\b{search}\\b";

            return Regex.Replace(text, pattern, replaceWith, RegexOptions.IgnoreCase);
        }
    }
}
