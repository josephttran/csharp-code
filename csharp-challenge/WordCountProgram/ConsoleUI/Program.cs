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
            VerbatimString verbatimString = new VerbatimString(tests[0]);
            VerbatimString verbatimStringTwo = new VerbatimString(tests[1]);

            InitilizeVerbatim(verbatimString);
            InitilizeVerbatim(verbatimStringTwo);

            Console.WriteLine("First string test[0] Values: ");
            verbatimString.DisplayDetails();

            Console.WriteLine("\nSecond string test[1] Values: ");
            verbatimStringTwo.DisplayDetails();
            Console.ReadLine();
        }

        static void InitilizeVerbatim(VerbatimString verbatimString)
        {
            verbatimString.WordCount = StringHelper.WordCount(verbatimString.MyString);
            verbatimString.CharacterCount = StringHelper.CharacterCount(verbatimString.MyString);
            verbatimString.CharacterMinusSpaceLineCount = StringHelper.CharacterMinusSpaceLineReturnCount(verbatimString.MyString);
            verbatimString.MostWordAmount = GetMaxAmountPair(StringHelper.GetEachWordAmount(verbatimString.MyString));
            verbatimString.MostAlphaCharacterAmount = GetMaxAmountPair(StringHelper.GetEachAlphaCharacterAmount(verbatimString.MyString));

            (string, int) GetMaxAmountPair(Dictionary<string, int> wordAmountPairs)
            {
                int valueMax = wordAmountPairs.Values.Max();
                string valueMaxKey = wordAmountPairs.Where(kv => kv.Value == valueMax).Max(kv => kv.Key);

                return (valueMaxKey, valueMax);
            }
        }
    }
}
