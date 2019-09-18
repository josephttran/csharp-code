using System;
using System.Collections.Generic;
using System.Linq;

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
                    List<int> factors = GetFactorList(inputNumber);
                    List<int> primeFactors = GetPrimeFactorList(inputNumber);

                    Console.WriteLine($"{ inputNumber } is Not a prime number");
                    PrintFactors("Factors", inputNumber, factors);
                    PrintFactors("Prime factors", inputNumber, primeFactors);
                    PrintLargestPrimeFactor(primeFactors);
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

        static List<int> GetFactorList(int inputNumber)
        {
            List<int> factorList = new List<int>();

            if (inputNumber <= 3)
            {
                return factorList;
            }

            for (int number = 2; number <= inputNumber / 2; number++)
            {
                if (inputNumber % number == 0)
                {
                    factorList.Add(number);
                }
            }

            return factorList;
        }

        static List<int> GetPrimeFactorList(int inputNumber)
        {
            List<int> primeFactorList = new List<int>();

            if (inputNumber <= 3)
            {
                return primeFactorList;
            }

            for (int number = 2; number <= inputNumber / 2; number++)
            {
                if (inputNumber % number == 0)
                {
                    if (IsPrime(number))
                    {
                        primeFactorList.Add(number);
                    }
                }
            }

            return primeFactorList;
        }

        static void PrintFactors(string description, int inputNumber, List<int> factors)
        {
            if (factors.Count != 0)
            {
                Console.Write($"{ description } of { inputNumber }: ");
                Console.WriteLine(String.Join(", ", factors));
            }
        }

        static void PrintLargestPrimeFactor(List<int> primeFactors)
        {
            if (primeFactors.Count != 0)
            {
                Console.WriteLine($"The largest prime factor in the list is { primeFactors.Max() }");
            }
        }
    }
}
