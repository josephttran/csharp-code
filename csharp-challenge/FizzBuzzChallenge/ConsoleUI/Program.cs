using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int number = 1; number <= 100; number++)
            {
                if (number % 3 == 0 && number % 5 == 0)
                {
                    Console.WriteLine($"FizzBuzz ({ number })");
                }
                else if (number % 3 == 0)
                {
                    Console.WriteLine($"Fizz ({ number })");
                }                
                else if (number % 5 == 0)
                { 
                    Console.WriteLine($"Buzz ({ number })");
                }
                else
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}
