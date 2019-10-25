using System;
using System.Collections.Generic;

namespace CachingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonModelMemoryCache personModelMemoryCache = new PersonModelMemoryCache(10);
            bool askForData = false;
            string userMenuInput;

            while (!askForData)
            {
                DisplayMenu();
                userMenuInput = Console.ReadLine();

                if (userMenuInput.ToLower() == "quit")
                {
                    break;
                }

                if (Int32.TryParse(userMenuInput, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RunPeople(personModelMemoryCache);
                            break;
                        case 2:
                            Console.WriteLine("todo choice 2");
                            break;
                        case 3:
                            Console.WriteLine("todo choice 2");
                            break;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            }

            Console.WriteLine("Application has ended");
            Console.ReadLine();
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nEnter quit to end the program else choose from the options");
            Console.WriteLine("1) Get People");
            Console.WriteLine("2) Get person by ID");
            Console.WriteLine("3) Get people by last name");
            Console.Write("Your choice: ");
        }

        static void DisplayPeople(List<PersonModel> people)
        {
            foreach (var personModel in people)
            {
                Console.WriteLine(personModel.ToString());
            }
        }

        static void RunPeople(PersonModelMemoryCache personModelMemoryCache)
        {
            List<PersonModel> people;
            string key = "People Key";

            Console.WriteLine();
            if (personModelMemoryCache.IsCacheValid(key))
            {
                people = personModelMemoryCache.GetPeopleCache();
            }
            else
            {
                DataAccess dataAccess = new DataAccess();
                people = dataAccess.SimulatedPersonListLookup();
                personModelMemoryCache.AddPeopleCache(key, people);
            }

            DisplayPeople(people);
        }
    }
}
