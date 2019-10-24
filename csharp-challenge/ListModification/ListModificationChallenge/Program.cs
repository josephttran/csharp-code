using System;
using System.Collections.Generic;
using System.Linq;

namespace ListModificationChallenge
{
    class Program
    {
        // DO NOT MODIFY THIS METHOD - if something isn't working, it means you haven't completed a method correctly
        static void Main(string[] args)
        {
            List<PersonModel> sampleList = CreateSampleList();
            List<PersonModel> results;

            // Goal Section
            Console.WriteLine("Standard Challenge Section");
            Console.WriteLine();

            results = InsertRecordLastIntoNewList(sampleList);
            Console.Write("Insert record Last into new list: ");
            if (results.Count > sampleList.Count && results[results.Count - 1].FullName == "Brown, Greg")
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            sampleList = CreateSampleList();
            results = InsertRecordFirstIntoNewList(sampleList);
            Console.Write("Insert record First into new list: ");
            if (results.Count > sampleList.Count && results[0].FullName == "Brown, Greg")
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            sampleList = CreateSampleList();
            results = InsertRecordInTheMiddleIntoNewList(sampleList);
            Console.Write("Insert record in the middle into new list: ");
            if (results.Count > sampleList.Count && results[3].FullName == "Brown, Greg")
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            sampleList = CreateSampleList();
            results = SortAndReturnANewList(sampleList);
            Console.Write("Sort a list into a new list: ");
            if (results[1].LastName == "Jones" && sampleList[1].LastName == "Storm")
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            // Bonus Section
            Console.WriteLine();
            Console.WriteLine("Bonus Challenge Section");
            Console.WriteLine();

            sampleList = CreateSampleList();
            InsertRecordLastIntoList(sampleList);
            Console.Write("Insert record Last into existing list: ");
            if (sampleList.Count == 6 && sampleList[5].FullName == "Brown, Greg")
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            sampleList = CreateSampleList();
            InsertRecordFirstIntoList(sampleList);
            Console.Write("Insert record First into existing list: ");
            if (sampleList.Count == 6 && sampleList[0].FullName == "Brown, Greg")
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            sampleList = CreateSampleList();
            InsertRecordInTheMiddleOfTheList(sampleList);
            Console.Write("Insert record in the middle into existing list: ");
            if (sampleList.Count == 6 && sampleList[3].FullName == "Brown, Greg")
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            sampleList = CreateSampleList();
            SortAList(sampleList);
            Console.Write("Sort an existing list: ");
            if (sampleList[1].LastName == "Jones")
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Console.WriteLine("Failed");
            }

            Console.ReadLine();
        }

        #region Standard Challenge
        private static List<PersonModel> InsertRecordLastIntoNewList(List<PersonModel> people)
        {
            List<PersonModel> output;
            PersonModel newPerson = new PersonModel { FirstName = "Greg", LastName = "Brown" };

            // Add a record to the end of the incoming list and return a new list that includes newPerson
            output = new List<PersonModel>(people)
            {
                newPerson
            };

            return output;
        }

        private static List<PersonModel> InsertRecordFirstIntoNewList(List<PersonModel> people)
        {
            List<PersonModel> output;
            PersonModel newPerson = new PersonModel { FirstName = "Greg", LastName = "Brown" };

            // Add a record to the beginning of the incoming list and return a new list that includes newPerson
            output = new List<PersonModel>
            {
                newPerson
            };

            foreach (var personModel in people)
            {
                output.Add(personModel);
            }

            return output;
        }

        private static List<PersonModel> InsertRecordInTheMiddleIntoNewList(List<PersonModel> people)
        {
            List<PersonModel> output;
            PersonModel newPerson = new PersonModel { FirstName = "Greg", LastName = "Brown" };
            int middle = (people.Count % 2 == 0)
                ? people.Count / 2
                : people.Count / 2 + 1;

            // Add a record after Paul Jones in the incoming list and return a new list that includes newPerson
            output = new List<PersonModel>(people);

            output.Insert(middle, newPerson);

            return output;
        }

        private static List<PersonModel> SortAndReturnANewList(List<PersonModel> people)
        {
            List<PersonModel> output;

            // Sort the incoming list values by fullname (ascending) and return a new list
            output = people.OrderBy(person => person.FullName).ToList();

            return output;
        }
        #endregion

        #region Bonus Challenge
        private static void InsertRecordLastIntoList(List<PersonModel> people)
        {
            PersonModel newPerson = new PersonModel { FirstName = "Greg", LastName = "Brown" };

            // Add a record to the end of the incoming list
            people.Add(newPerson);
        }

        private static void InsertRecordFirstIntoList(List<PersonModel> people)
        {
            PersonModel newPerson = new PersonModel { FirstName = "Greg", LastName = "Brown" };

            // Add a record to the beginning of the incoming list
            people.Insert(0, newPerson);
        }

        private static void InsertRecordInTheMiddleOfTheList(List<PersonModel> people)
        {
            PersonModel newPerson = new PersonModel { FirstName = "Greg", LastName = "Brown" };
            int middle = (people.Count % 2 == 0)
                ? people.Count / 2
                : people.Count / 2 + 1;

            // Add a record after Paul Jones in the incoming list
            people.Insert(middle, newPerson);

        }

        private static void SortAList(List<PersonModel> people)
        {
            // Sort the incoming list values by fullname (ascending)
            people.Sort(ComparePerson);

            int ComparePerson(PersonModel personX, PersonModel personY)
            {
                return personX.FullName.CompareTo(personY.FullName);
            }
        }
        #endregion

        // Leave this method alone. It is used for specific setup.
        private static List<PersonModel> CreateSampleList()
        {
            var output = new List<PersonModel>
            {
                new PersonModel{ FirstName = "Tim", LastName = "Corey"},
                new PersonModel{ FirstName = "Sue", LastName = "Storm"},
                new PersonModel{ FirstName = "Paul", LastName = "Jones"},
                new PersonModel{ FirstName = "Jane", LastName = "Smith"},
                new PersonModel{ FirstName = "Betty", LastName = "Smith"}
            };

            return output;
        }
    }
}
