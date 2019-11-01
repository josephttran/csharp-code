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
            List<object> letterAndCounts = StringToLetterAndCounts(words);
            List<object> letterAndCountsSortByLetter = SortObjectByLetter(letterAndCounts);
            List<object> letterAndCountsSortByCount = SortObjectByCount(letterAndCounts);

            Console.WriteLine(words);
            Console.WriteLine($"\n{ words } sorted by letter:");
            Console.WriteLine(String.Join(", ", orderedLetters.ToArray()));

            Console.WriteLine("\nLetter count objects sorted by letter:");
            DisplayLetterAndCounts(letterAndCountsSortByLetter);

            Console.WriteLine("\nLetter count objects sorted by count in descending order:");
            DisplayLetterAndCounts(letterAndCountsSortByCount);
        }

        static List<char> StringToOrderedLetters(string words)
        {
            List<char> orderedLetters =
                ( from character in words
                  where char.IsLetter(character)
                  orderby character.ToString().ToLower()
                  select character ).ToList();

            return orderedLetters;
        }

        static List<object> StringToLetterAndCounts(string words)
        {
            List<object> letterAndCounts =
                ( from character in words
                  where char.IsLetter(character)
                  let letter = character
                  group character by letter
                  into letterGroup
                  select new { Letter = letterGroup.Key, Count = letterGroup.Count() } as object ).ToList();

            return letterAndCounts;
        }

        static List<object> SortObjectByLetter(List<object> LetterAndCounts)
        {
            List<object> sortedByLetter =
                ( from LetterAndCount in LetterAndCounts
                  orderby LetterAndCount.GetType().GetProperty("Letter").GetValue(LetterAndCount).ToString().ToLower()
                  select LetterAndCount ).ToList();

            return sortedByLetter;
        }

        static List<object> SortObjectByCount(List<object> LetterAndCounts)
        {
            List<object> sortedByCount =
                ( from LetterAndCount in LetterAndCounts
                  orderby LetterAndCount.GetType().GetProperty("Count").GetValue(LetterAndCount) descending
                  select LetterAndCount ).ToList();

            return sortedByCount;
        }

        static void DisplayLetterAndCounts(List<object> LetterAndCounts)
        {
            foreach (object LetterAndCount in LetterAndCounts)
            {
                char letter = (char) LetterAndCount.GetType().GetProperty("Letter").GetValue(LetterAndCount);
                int letterCount = (int) LetterAndCount.GetType().GetProperty("Count").GetValue(LetterAndCount);

                Console.WriteLine($"{ letter }: { letterCount }");
            }
        }
    }
}
