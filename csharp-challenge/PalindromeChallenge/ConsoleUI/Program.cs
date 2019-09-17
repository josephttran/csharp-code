using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "racecar";
            int number = 12321;

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
        }

        static public bool IsPalindrome(string str)
        {
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
    }
}
