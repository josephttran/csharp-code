using System;

namespace ConsoleUI
{
    public static class ExtensionMethod
    {
        public static void Print(this string str)
        {
            Console.WriteLine(str);
        }

        public static void Excite(this string str)
        {
            string newString = str.Replace(".", "!");

            Console.WriteLine(newString);
        }

        public static Person Fill(this Person person)
        {
            Console.Write("\nWhat is the person's first name? ");
            person.FirstName = Console.ReadLine();

            Console.Write("\nWhat is the person's last name? ");
            person.LastName = Console.ReadLine();

            bool isValidAge = false;
            string input;

            while (!isValidAge)
            {
                Console.Write("\nWhat is the person's age? ");
                input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result > 0 && result < 200)
                    {
                        person.Age = result;
                        isValidAge = true;
                    }
                }

                if (!isValidAge)
                {
                    Console.WriteLine("Error: invalid input!");
                }
            }

            return person;
        }

        public static void Print(this Person person)
        {
            Console.WriteLine($"\nThis person is { person.FirstName } { person.LastName } ({ person.Age })");
        }
    }
}
