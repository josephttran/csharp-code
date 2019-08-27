using System;
using DataLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string actionToTake = "";

            DataAccess dataAccess = new DataAccess();

            do
            {
                Console.Write("What action do you want to take (Display, Add, or Quit): ");
                actionToTake = Console.ReadLine();

                switch (actionToTake.ToLower())
                {
                    case "display":
                        Display();
                        break;
                    case "add":
                        object firstLastName = getName();
                        Add(firstLastName);
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
            } while (actionToTake.ToLower() != "quit");

            object getName()
            {
                Console.Write("What is the first name: ");
                string firstName = Console.ReadLine();

                Console.Write("What is the last name: ");
                string lastName = Console.ReadLine();

                return new { FirstName = firstName, LastName = lastName };
            }

            void Display()
            {
                var records = dataAccess.GetRecords<UserModel>();

                Console.WriteLine();
                records.ForEach(x => Console.WriteLine($"{ x.FirstName } { x.LastName }"));
                Console.WriteLine();
            }

            void Add(object firstLastName)
            {
                dataAccess.CreateRecord(firstLastName);
            }
        }
    }
}
