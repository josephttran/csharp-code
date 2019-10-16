using System;
using System.Globalization;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;

            while (!quit)
            {
                Console.Write("\nEnter quit to end the program else press the enter key to continue: ");
                string input = Console.ReadLine();

                if (input == "quit")
                {
                    quit = true;
                }
                else
                {
                    RunBirthday();
                }
            }
        }

        static void RunBirthday()
        {
            DateTime birthday = GetBirthdate();
            int ageInYears = AgeHelper.CalculateAgeInYears(birthday);
            int ageInMonths = AgeHelper.CalculateAgeInMonths(birthday);
            int ageInDays = AgeHelper.CalculateAgeInDays(birthday);

            Console.WriteLine($"Date of birth is { birthday.ToShortDateString() }");
            Console.WriteLine($"The user is { ageInYears } years old");
            Console.WriteLine($"The user is { ageInMonths } months old");
            Console.WriteLine($"The user is { ageInDays } days old");
        }

        static DateTime GetBirthdate()
        {
            bool valid = false;
            DateTime birthday = DateTime.Now;

            while (!valid)
            {
                Console.Write("\nEnter your birthdate (MM/dd/yyyy): ");
                string birthdayInput = Console.ReadLine();

                if (DateTime.TryParseExact(birthdayInput, "MM/dd/yyyy", null, DateTimeStyles.None, out birthday))
                {
                    if (birthday.CompareTo(DateTime.Now) < 0)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: birthday cannot be in the future!");
                    }
                }
                else
                {
                    Console.WriteLine("Error: unable to process birthday entered!");
                }
            }

            return birthday;
        }
    }
}
