using System;
using System.Collections.Generic;
using System.Linq;

namespace CachingChallenge
{
    public class DataAccess
    {
        List<PersonModel> _people = new List<PersonModel>
        {
            new PersonModel{ Id = 1, FirstName = "Tim", LastName = "Corey" },
            new PersonModel{ Id = 2, FirstName = "Joe", LastName = "Jones" },
            new PersonModel{ Id = 3, FirstName = "Sue", LastName = "Storm" },
            new PersonModel{ Id = 4, FirstName = "Mary", LastName = "Jones" },
            new PersonModel{ Id = 5, FirstName = "Lisa", LastName = "Simmons" },
            new PersonModel{ Id = 6, FirstName = "Tom", LastName = "Smith" }
        };

        public List<PersonModel> SimulatedPersonListLookup()
        {
            Console.WriteLine("The database was accessed");
            return _people;
        }

        public PersonModel SimulatedPersonById(int id)
        {
            Console.WriteLine("The database was accessed for an individual lookup");
            return _people.FirstOrDefault(x => x.Id == id);
        }

        public List<PersonModel> SimulatedPersonListByLastName(string lastName)
        {
            Console.WriteLine("The database was accessed for a last name query");
            return _people.FindAll(x => x.LastName == lastName);
        }
    }
}
