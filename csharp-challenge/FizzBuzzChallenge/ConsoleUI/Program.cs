using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string word;

            for (int number = 1; number <= 100; number++)
            {
                word = "";

                if (number % 3 == 0)
                {
                    word = "Fizz";
                }

                if (number % 5 == 0)
                {
                    word += "Buzz";
                }

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
    }
}
