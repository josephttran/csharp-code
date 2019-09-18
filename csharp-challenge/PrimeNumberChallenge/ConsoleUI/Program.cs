using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            Console.Write("Enter a number: ");
            int inputNumber = int.Parse(Console.ReadLine());

            while (!quit)
            {
                if (IsPrime(inputNumber))
                {
                    Console.WriteLine($"{ inputNumber } is a prime number");
                }
                else
                {
                    Console.WriteLine($"{ inputNumber } is Not a prime number");
                }

                Console.Write("\nEnter a number: ");
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out int result))
                {
                    inputNumber = result;
                }
                else
                {
                    quit = true;
                } 
            }
        }

        static bool IsPrime(int inputNumber)
        {
            if (inputNumber < 2)
            {
                return false;
            }

            for (int number = 2; number <= Math.Sqrt(inputNumber); number++)
            {
                if (inputNumber % number == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
