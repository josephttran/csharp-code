using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = "Hello World";
            List<char> orderedLetters = StringToOrderedLetters(words);

            Console.WriteLine(words);
            Console.WriteLine(String.Join(", ", orderedLetters.ToArray()));
        }

        static List<char> StringToOrderedLetters(string words)
        {
            return words.Where(character => char.IsLetter(character))
                        .OrderBy(character => character.ToString().ToLower())
                        .ToList();
        }
    }
}
