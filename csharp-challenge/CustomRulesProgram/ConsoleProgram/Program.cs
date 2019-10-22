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

            Company companyOne = new Company
            {
                Name = "Loopers",
                PostalCode = "08423"
            };

            Company companyTwo = new Company
            {
                Name = "LoopersCorey",
                PostalCode = "84656"
            };

            ApplyRules<Person>(Rules, personOne);
            ApplyRules<Person>(Rules, personTwo);

            ApplyRules<Company>(Rules, companyOne);
            ApplyRules<Company>(Rules, companyTwo);
        }

        static void ApplyRules<T>(Action<T> function, T obj)
        {
            function(obj);
        }

        static void Rules(Person person)
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

        static void Rules(Company company)
        {
            Console.WriteLine($"\n{ company.Name }: ");

            if (company.Name.ToLower().Contains("corey"))
            {
                if ((company.Name.ToLower() == "iamtimcorey"))
                {
                    Console.WriteLine("Tim's Company");
                }
                else
                {
                    Console.WriteLine("A company owned by a Corey");
                }
            };

            if (company.PostalCode.StartsWith("08"))
            {
                Console.WriteLine("A company in New Jersey");
            }
        }
    }
}
