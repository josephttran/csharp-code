using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace CachingChallenge
{
    class PersonModelMemoryCache
    {
        private MemoryCache Cache { get; set; }
        public MemoryCacheEntryOptions CacheEntryOptions { get; set; }
        public string PeopleKey { get; private set; }

        public PersonModelMemoryCache(int sizeLimit)
        {
            Cache = new MemoryCache(
                new MemoryCacheOptions
                {
                    SizeLimit = sizeLimit
                }
            );

            CacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSize(1)
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));
        }

        public void AddPeopleCache(string key, List<PersonModel> people)
        {
            PeopleKey = key;
            Cache.Set(PeopleKey, people, CacheEntryOptions);
        }

        public List<PersonModel> GetPeopleCache()
        {
            List<PersonModel> people = new List<PersonModel>();

            if (Cache.TryGetValue(PeopleKey, out List<PersonModel> cachePeople))
            {
                people = cachePeople;
                Console.WriteLine("Data from cache");
            }

            return people;
        }

        public bool IsCacheValid(string key)
        {
            if (Cache.TryGetValue(key, out _))
            {
                return true;
            }

            return false;
        }
    }
}
