using System;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = "ra c22.rea ER%&$22car";
            int number = 12321;
            double myDouble = 12.321;
            bool isStringPalindrome = IsPalindrome(myString);
            bool isNumberPalindrome = IsPalindrome(number);
            bool isDoublePalindrome = IsPalindrome(myDouble);

            PrintIsPalindrome(myString, isStringPalindrome);
            PrintIsPalindrome(number, isNumberPalindrome);
            PrintIsPalindrome(myDouble, isDoublePalindrome);
        }

        /* Remove space and special characters from string then convert to lowercase */
        static public string CleanString(string myString)
        {
            string pattern = @"\W";

            myString = Regex.Replace(myString, pattern, String.Empty).ToLower();

            return myString;
        }

        static public bool IsPalindrome(string myString)
        {
            myString = CleanString(myString);

            for (int index = 0; index < myString.Length / 2; index++)
            {
                if (myString[index] != myString[myString.Length - 1 - index])
                {
                    return false;
                }
            }

            return true;
        }

        static public bool IsPalindrome(int number)
        {
            string myString = number.ToString();

            for (int index = 0; index < myString.Length / 2; index++)
            {
                if (myString[index] != myString[myString.Length - 1 - index])
                {
                    return false;
                }
            }

            return true;
        }

        static public bool IsPalindrome(double myDouble)
        {
            string myString = myDouble.ToString().ToLower();

            myString = Regex.Replace(myString, @".", String.Empty);

            for (int index = 0; index < myString.Length / 2; index++)
            {
                if (myString[index] != myString[myString.Length - 1 - index])
                {
                    return false;
                }
            }

            return true;
        }

        static void PrintIsPalindrome<T>(T input, bool isPalindrome)
        {
            if (isPalindrome)
            {
                Console.WriteLine($"{ input } is a palindrome");
            }
            else
            {
                Console.WriteLine($"{ input } is not a palindrome");
            }
        }
    }
}
