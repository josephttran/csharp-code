using System;
using System.Collections.Generic;
using System.Linq;
using StringHelperLibrary;

namespace ConsoleUI
{
    class Program
    {
        private static string[] tests = new string[]
        {
            @"The test of the 
            best way to handle

multiple lines,   extra spaces and more.",
            @"Using the starter app, create code that will 
loop through the strings and identify the total 
character count, the number of characters
excluding whitespace (including line returns), and the
number of words in the string. Finally, list each word, ensuring it
is a valid word."
        };

        /* 
            First string (tests[0]) Values:
            Total Words: 14
            Total Characters: 89
            Character count (minus line returns and spaces): 60
            Most used word: the (2 times)
            Most used character: e (10 times)

            Second string (tests[1]) Values:
            Total Words: 45
            Total Characters: 276
            Character count (minus line returns and spaces): 230
            Most used word: the (6 times)
            Most used character: t (24 times)
        */

        static void Main(string[] args)
        {
            (string, int) wordAmountTestZero = GetMaxWordAmountPair(StringHelper.GetEachWordAmount(tests[0]));
            (string, int) wordAmountTestOne = GetMaxWordAmountPair(StringHelper.GetEachWordAmount(tests[1]));

            Console.WriteLine("First string test[0] Values: ");
            PrintStringInfo(tests[0], wordAmountTestZero);

            Console.WriteLine("\nSecond string test[1] Values: ");
            PrintStringInfo(tests[1], wordAmountTestOne);

            Console.ReadLine();
        }

        static void PrintStringInfo(string myString, (string, int) wordAmountPair)
        {
            Console.WriteLine($"Total words: { StringHelper.WordCount(myString) }");
            Console.WriteLine($"Total Charactors: { StringHelper.CharacterCount(myString) }");
            Console.WriteLine($"Total Charactors minus spaces and line return: { StringHelper.CharacterMinusSpaceLineReturnCount(myString) }");
            Console.WriteLine($"Most use words: { wordAmountPair.Item1  } ({ wordAmountPair.Item2 } times)");
        }

        static (string, int) GetMaxWordAmountPair(Dictionary<string, int> wordAmountPairs)
        {
            int valueMax = wordAmountPairs.Values.Max();
            string valueMaxKey = wordAmountPairs.Where(kv => kv.Value == valueMax).Max(kv => kv.Key);

            return (valueMaxKey, valueMax);
        }
    }
}
