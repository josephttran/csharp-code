using System.Globalization;

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
            string[] words = text.Split(" ");

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].ToLower() == search.ToLower())
                {
                    words[i] = replaceWith;
                }
            }

            string replaceString = string.Join(" ", words);

            return replaceString;
        }
    }
}
