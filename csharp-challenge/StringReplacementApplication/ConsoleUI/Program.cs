using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string primaryTextPath = @"../../../primary.txt";
            string replacedPrimaryTextPath = @"../../../replacedPrimary.txt";

            Primary(primaryTextPath, replacedPrimaryTextPath);
        }

        static void Primary(string primaryTextPath, string replacedPrimaryTextPath)
        {
            if (!File.Exists(primaryTextPath))
            {
                Console.WriteLine($"File not found {primaryTextPath}");
            }
            else
            {
                Console.Write("What text would you like to replace? ");
                string textToReplace = Console.ReadLine();

                Console.Write("Now what do you want to replace it with? ");
                string replaceWith = Console.ReadLine();

                string primaryText = File.ReadAllText(primaryTextPath);
                string pattern = @$"\b{ textToReplace }\b";
                string replacedPrimaryText = Regex.Replace(primaryText, pattern, replaceWith);

                File.WriteAllText(replacedPrimaryTextPath, replacedPrimaryText);
            }
        }
    }
}
