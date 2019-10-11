using System;

using ConsoleProgram.Models;

namespace ConsoleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Person personOne = new Person
            {
                FirstName = "Hoddy",
                LastName = "Corey",
                PostalCode = "18423"
            };
            
            Person personTwo = new Person
            {
                FirstName = "Toggle",
                LastName = "Cappers",
                PostalCode = "45423"
            };

            ApplyRules(personOne);
            ApplyRules(personTwo);
        }

        static void ApplyRules(Person person)
        {
            Console.WriteLine($"\n{ person.FirstName } { person.LastName }: ");

            if (person.LastName.ToLower() == "corey")
            {
                if (person.FirstName.ToLower() != "tim")
                {
                    Console.WriteLine("Possibly related to Tim Corey");
                }
            };

            if (person.FirstName.ToLower().StartsWith("t") && person.LastName.ToLower().StartsWith("c"))
            {
                Console.WriteLine("Same initials as Tim Corey");
            }

            if (person.PostalCode.StartsWith("18"))
            {
                Console.WriteLine("In the same general area as Tim");
            }
        }
    }
}
