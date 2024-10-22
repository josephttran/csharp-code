﻿using Microsoft.Extensions.Caching.Memory;
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
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
        }

        public void AddAllPeopleCache(string key, List<PersonModel> people)
        {
            PeopleKey = key;
            Cache.Set(PeopleKey, people, CacheEntryOptions);
        }
        public void AddPeopleCache(string key, List<PersonModel> people)
        {
            Cache.Set(key, people, CacheEntryOptions);
        }

        public void AddPersonCache(string personKey, PersonModel person)
        {
            Cache.Set(personKey, person, CacheEntryOptions);
        }

        public List<PersonModel> GetAllPeopleCache()
        {
            List<PersonModel> people = new List<PersonModel>();

            if (Cache.TryGetValue(PeopleKey, out List<PersonModel> cachePeople))
            {
                people = cachePeople;
                Console.WriteLine("Data from cache");
            }

            return people;
        }

        public List<PersonModel> GetPeopleCache(string lastNameKey)
        {
            Console.WriteLine("People data with last name from cache");
            return (List<PersonModel>) CacheExtensions.Get(Cache, lastNameKey);
        }

        public PersonModel GetPersonCache(string key)
        {
            Console.WriteLine("Person data from cache");
            return (PersonModel) CacheExtensions.Get(Cache, key);
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
