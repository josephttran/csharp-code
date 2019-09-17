using System;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "ra c22.rea ER%&$22car";
            int number = 12321;
            double myDouble = 12.321;

            if (IsPalindrome(str))
            {
                Console.WriteLine($"{ str } is a palindrome");
            }
            else
            {
                Console.WriteLine($"{ str } is not a palindrome");
            }

            if (IsPalindrome(number))
            {
                Console.WriteLine($"{ number } is a palindrome");
            }
            else
            {
                Console.WriteLine($"{ number } is not a palindrome");
            }

            if (IsPalindrome(myDouble))
            {
                Console.WriteLine($"{ myDouble } is a palindrome");
            }
            else
            {
                Console.WriteLine($"{ myDouble } is not a palindrome");
            }
        }

        /* Remove space and special characters from string then convert to lowercase */
        static public string CleanString(string str)
        {
            string pattern = @"\W";

            str = Regex.Replace(str, pattern, String.Empty).ToLower();

            return str;
        }

        static public bool IsPalindrome(string str)
        {
            str = CleanString(str);

            for (int index = 0; index < str.Length / 2; index++)
            {
                if (str[index] != str[str.Length - 1 - index])
                {
                    return false;
                }
            }

            return true;
        }

        static public bool IsPalindrome(int number)
        {
            string str = number.ToString();

            for (int index = 0; index < str.Length / 2; index++)
            {
                if (str[index] != str[str.Length - 1 - index])
                {
                    return false;
                }
            }

            return true;
        }

        static public bool IsPalindrome(double myDouble)
        {
            string str = myDouble.ToString().ToLower();

            str = Regex.Replace(str, @".", String.Empty);

            for (int index = 0; index < str.Length / 2; index++)
            {
                if (str[index] != str[str.Length - 1 - index])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
