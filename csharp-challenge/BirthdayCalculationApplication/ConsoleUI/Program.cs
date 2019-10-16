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
            Person person = new Person(birthday);

            Console.WriteLine(birthday.ToString());
            Console.WriteLine($"The user is { person.AgeInYears } years old");
            Console.WriteLine($"The user is { person.AgeInMonths } months old");
            Console.WriteLine($"The user is { person.AgeInDays } days old");
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
