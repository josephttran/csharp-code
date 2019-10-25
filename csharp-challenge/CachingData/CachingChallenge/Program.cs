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
                            int id = GetIdFromUser();
                            RunPersonById(personModelMemoryCache, id);
                            break;
                        case 3:
                            string lastName = GetLastNameFromUser();
                            RunPeopleWithLastName(personModelMemoryCache, lastName);
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

        static int GetIdFromUser()
        {
            bool isInteger = false;
            string userInput;
            int id = -1;

            while (!isInteger)
            {
                Console.Write("\nEnter a user Id: ");
                userInput = Console.ReadLine();

                if (Int32.TryParse(userInput, out int value))
                {
                    id = value;
                    isInteger = true;
                }
                else
                {
                    Console.WriteLine("Error: Id should be an integer!");
                }
            }

            return id;
        }
        static string GetLastNameFromUser()
        {
            bool isString = false;
            string userInput = "";

            while (!isString)
            {
                Console.Write("\nEnter last name: ");
                userInput = Console.ReadLine();

                foreach (char c in userInput)
                {
                    if (!char.IsLetter(c))
                    {
                        Console.WriteLine("Error: Last name should contain only letters!");
                        break;
                    }

                    isString = true;
                }
            }

            return userInput;
        }

        static void RunPeople(PersonModelMemoryCache personModelMemoryCache)
        {
            List<PersonModel> people;
            string key = "People Key";

            Console.WriteLine();
            if (personModelMemoryCache.IsCacheValid(key))
            {
                people = personModelMemoryCache.GetAllPeopleCache();
            }
            else
            {
                DataAccess dataAccess = new DataAccess();
                people = dataAccess.SimulatedPersonListLookup();
                personModelMemoryCache.AddAllPeopleCache(key, people);
            }

            DisplayPeople(people);
        }

        static void RunPersonById(PersonModelMemoryCache personModelMemoryCache, int id)
        {
            PersonModel person;
            string key = $"Person { id }";

            Console.WriteLine();
            if (personModelMemoryCache.IsCacheValid(key))
            {
                person = personModelMemoryCache.GetPersonCache(key);
            }
            else
            {
                DataAccess dataAccess = new DataAccess();
                person = dataAccess.SimulatedPersonById(id);
                personModelMemoryCache.AddPersonCache(key, person);
            }

            Console.WriteLine(person.ToString());
        }

        static void RunPeopleWithLastName(PersonModelMemoryCache personModelMemoryCache, string lastName)
        {
            List<PersonModel> people;
            string key = $"People { lastName }";

            Console.WriteLine();
            if (personModelMemoryCache.IsCacheValid(key))
            {
                people = personModelMemoryCache.GetPeopleCache(key);
            }
            else
            {
                DataAccess dataAccess = new DataAccess();
                people = dataAccess.SimulatedPersonListByLastName(lastName);
                personModelMemoryCache.AddPeopleCache(key, people);
            }

            if (people.Count > 0)
            {
                DisplayPeople(people);
            }
            else
            {
                Console.WriteLine($"No person with last name { lastName } exist");
            }
        }
    }
}
