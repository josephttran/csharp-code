using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //string primaryTextPath = @"../../../primary.txt";
            //string replacedPrimaryTextPath = @"../../../replacedPrimary.txt";

            //Primary(primaryTextPath, replacedPrimaryTextPath);

            string bonusTextPath = @"../../../bonus.txt";
            string replacedBonusTextPath = @"../../../replacedBonus.txt";

            Bonus(bonusTextPath, replacedBonusTextPath);
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

        static void Bonus(string bonusTextPath, string replacedBonusTextPath)
        {
            if (!File.Exists(bonusTextPath))
            {
                Console.WriteLine($"File not found {bonusTextPath}");
            }
            else
            {
                string bonusText = File.ReadAllText(bonusTextPath);

                MatchCollection parameters = Regex.Matches(bonusText, @"{\w+}");

                var uniqueParameters = parameters
                    .Select(match => Regex.Replace(match.Value, "[{}]", ""))
                    .Distinct();

                string replaceWith;

                foreach (var parameter in uniqueParameters)
                {
                    Console.Write($"What do you want to replace { parameter } with? ");

                    replaceWith = Console.ReadLine();
                    bonusText = bonusText.Replace($"{{{ parameter }}}", $"{{{ replaceWith }}}");
                }

                File.WriteAllText(replacedBonusTextPath, bonusText);
            }
        }
    }
}
