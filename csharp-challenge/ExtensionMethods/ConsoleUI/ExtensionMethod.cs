using System;

namespace ConsoleUI
{
    public static class ExtensionMethod
    {
        public static void Print(this string str)
        {
            Console.WriteLine(str);
        }

        public static void Excite(this string str)
        {
            string newString = str.Replace(".", "!");

            Console.WriteLine(newString);
        }
    }
}
