using System;

namespace StringHelperLibrary
{
    public class VerbatimString
    {
        public string MyString { get; set; }
        public int WordCount { get; set; }
        public int CharacterCount { get; set; }
        public int CharacterMinusSpaceLineCount { get; set; }
        public (string, int) MostWordAmount { get; set; }
        public (string, int) MostAlphaCharacterAmount { get; set; }

        public VerbatimString(string myString)
        {
            MyString = myString;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Total words: { WordCount }");
            Console.WriteLine($"Total Characters: { CharacterCount }");
            Console.WriteLine($"Total Characters minus spaces and line return: { CharacterMinusSpaceLineCount }");
            Console.WriteLine($"Most used word: { MostWordAmount.Item1  } ({ MostWordAmount.Item2 } times)");
            Console.WriteLine($"Most used character: { MostAlphaCharacterAmount.Item1  } ({ MostAlphaCharacterAmount.Item2 } times)");
        }
    }
}
