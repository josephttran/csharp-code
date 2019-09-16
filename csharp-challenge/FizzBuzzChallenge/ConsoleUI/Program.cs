using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = 120;
            SortedDictionary<int, string> wordByNumber = new SortedDictionary<int, string>();

            wordByNumber.Add(5, "Buzz");
            wordByNumber.Add(3, "Fizz");
            wordByNumber.Add(7, "Jazz");

            for (int number = 1; number <= maxNumber; number++)
            {
                string word = HandleSpecialNumber(number, wordByNumber);

                if (word == "")
                {
                    Console.WriteLine(number);
                }
                else
                {
                    Console.WriteLine($"{ word } ({ number })");
                }
            }
        }

        static string HandleSpecialNumber(int number, SortedDictionary<int, string> wordByNumber)
        {
            string word = "";

            foreach (int key in wordByNumber.Keys)
            {
                if (number % key == 0)
                {
                    word += wordByNumber[key];
                }
            }

            return word;
        }
    }
}
