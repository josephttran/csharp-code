using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

using APIHelperLibrary.StarWars.Model;
using APIHelperLibrary.StarWars.Services;

namespace ConsoleUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IMemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = 87
            });

            bool quit = false;

            while (!quit)
            {
                Console.Write("\nFind a Stars War person (yes, no)? ");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "yes")
                {
                    var starWarsPeopleServices = new StarWarsPeopleServices();
                    StarWarsPerson starWarsPerson;
                    int personId = GetIdFromInput();

                    if (memoryCache.TryGetValue($"person { personId }", out StarWarsPerson person))
                    {
                        starWarsPerson = person;
                    }
                    else
                    {
                        starWarsPerson = await starWarsPeopleServices.GetStarWarsPerson(personId);
                        MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetSize(1)
                            .SetAbsoluteExpiration(TimeSpan.FromHours(1));

                        memoryCache.Set($"person { personId }", starWarsPerson, cacheEntryOptions);
                    }

                    string json = starWarsPeopleServices.GetSerializePerson(starWarsPerson);

                    StarWarsPrinter.ShowPrettyFilteredJson(json);
                    // StarWarsPrinter.ShowPrettyFullJson(json);
                }
                else if (userInput.ToLower() == "no")
                {
                    quit = true;
                }
                else
                {
                    Console.WriteLine("Invalid answer!");
                }
            }
        }

        static int GetIdFromInput()
        {
            int id = -1;
            bool valid = false;

            while (!valid)
            {
                Console.Write("\nEnter an ID: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int inputID))
                {
                    valid = true;
                    id = inputID;
                }
                else
                {
                    Console.WriteLine("Error: Please enter a number!");
                }
            }

            return id;
        }
    }
}
