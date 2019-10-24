using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;

namespace CachingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IMemoryCache memoryCache = new MemoryCache(
                new MemoryCacheOptions
                {
                    SizeLimit = 6
                }))
            {
                bool askForData = false;
                string userInput;
                DataAccess dataAccess = new DataAccess();
                List<PersonModel> people = new List<PersonModel>();

                while (!askForData)
                {
                    Console.Write("\nEnter quit to end the program else hit enter: ");
                    userInput = Console.ReadLine();

                    if (userInput.ToLower() == "quit")
                    {
                        break;
                    }

                    if (memoryCache.TryGetValue("People Data", out List<PersonModel> cachePeople))
                    {
                        people = cachePeople;
                        Console.WriteLine("Data from cache");
                    }
                    else
                    {
                        people = dataAccess.SimulatedPersonListLookup();

                        MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetSize(1)
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

                        memoryCache.Set("People Data", people, cacheEntryOptions);
                    }

                    foreach (var personModel in people)
                    {
                        Console.WriteLine(personModel.ToString());
                    }
                }
            }

            Console.WriteLine("Application has ended");
            Console.ReadLine();
        }
    }
}
