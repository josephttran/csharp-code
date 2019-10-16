using System;
using System.Globalization;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime birthday = GetBirthdate();

            Console.WriteLine(birthday.ToString());
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
