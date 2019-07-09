using System;
using System.Collections.Generic;

using HelperLibrary;

namespace ConsoleApp
{
    class Program
    {
        private static List<Person> people = new List<Person>();

        static void Main(string[] args)
        {
            SetUpData();

            GreetAllPeople();
        }
        
        private static void SetUpData()
        {
            people.Add(new Person { Firstname = "Alice", Lastname = "Eve" });
            people.Add(new Person { Firstname = "Bob", Lastname = "Tom" });
            people.Add(new Person { Firstname = "Carry", Lastname = "Sandy" });
        }

        private static void GreetAllPeople()
        {
            foreach (var person in people)
            {
                Console.WriteLine($"Hello { person.Firstname } { person.Lastname }");                
            }
        }
    }
}
