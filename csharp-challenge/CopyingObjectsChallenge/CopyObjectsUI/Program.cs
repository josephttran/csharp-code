using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace CopyObjectsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonModel firstPerson = new PersonModel
            {
                FirstName = "Sue",
                LastName = "Storm",
                DateOfBirth = new DateTime(1998, 7, 19),
                Addresses = new List<AddressModel>
                {
                    new AddressModel
                    {
                        StreetAddress = "101 State Street",
                        City = "Salt Lake City",
                        State = "UT",
                        ZipCode = "76321"
                    },
                    new AddressModel
                    {
                        StreetAddress = "842 Lawrence Way",
                        City = "Jupiter",
                        State = "FL",
                        ZipCode = "22558"
                    }
                }
            };

            string newName = "Bob";
            string newAddress = "123 Bob Address";

            // Creates a second PersonModel object
            PersonModel secondPerson = new PersonModel();

            // Set the value of the secondPerson to be a copy of the firstPerson
            CopyPersonMethodOne(firstPerson, secondPerson);

            // Update the secondPerson's FirstName to "Bob" 
            secondPerson.FirstName = newName;

            // Change the Street Address for each of Bob's addresses to a different value
            SetPersonStreetAddress(secondPerson, newAddress);

            // Ensure that the following statements are true
            ComparePerson(firstPerson, secondPerson);


            // Creates a another PersonModel object
            PersonModel thirdPerson = new PersonModel();

            CopyPersonMethodTwo(firstPerson, ref thirdPerson);
            thirdPerson.FirstName = newName;
            SetPersonStreetAddress(thirdPerson, newAddress);
            ComparePerson(firstPerson, thirdPerson);


            // Creates a another PersonModel object
            CopyPersonMethodThree(firstPerson, out PersonModel fourthPerson);
            fourthPerson.FirstName = newName;
            SetPersonStreetAddress(fourthPerson, newAddress);
            ComparePerson(firstPerson, fourthPerson);

            Console.ReadKey();
        }

        static void CopyPersonMethodOne(PersonModel firstPerson, PersonModel secondPerson)
        {
            PropertyInfo[] firstPersonProperties = firstPerson.GetType().GetProperties();

            foreach (var property in firstPersonProperties)
            {
                if (property.PropertyType.Name.ToString() == "List`1")
                {
                    if (property.GetValue(firstPerson) != null)
                    {
                        List<AddressModel> addresses = new List<AddressModel>();
                        List<AddressModel> firstPersonAddresses = property.GetValue(firstPerson) as List<AddressModel>;

                        foreach (AddressModel address in firstPersonAddresses)
                        {
                            AddressModel newAddress = new AddressModel
                            {
                                StreetAddress = address.StreetAddress,
                                City = address.City,
                                State = address.State,
                                ZipCode = address.ZipCode
                            };

                            addresses.Add(newAddress);
                        }

                        secondPerson.GetType().GetProperty(property.Name).SetValue(secondPerson, addresses);
                    }
                }
                else
                {
                    var value = property.GetValue(firstPerson);
                    secondPerson.GetType().GetProperty(property.Name).SetValue(secondPerson, value);
                }
            }
        }

        static void CopyPersonMethodTwo(PersonModel firstPerson, ref PersonModel secondPerson)
        {
            List<AddressModel> addresses = new List<AddressModel>();

            secondPerson = new PersonModel
            {
                FirstName = firstPerson.FirstName,
                LastName = firstPerson.LastName,
                DateOfBirth = firstPerson.DateOfBirth,
            };

            secondPerson.Addresses = firstPerson.Addresses.Select(person => new AddressModel
            {
                StreetAddress = person.StreetAddress,
                State = person.State,
                City = person.City,
                ZipCode = person.ZipCode
            }).ToList();
        }

        static void CopyPersonMethodThree(PersonModel firstPerson, out PersonModel secondPerson)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(stream, firstPerson);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine($"Failed to deserialize: { exception.Message}");
                throw;
            }

            try
            {
                stream.Position = 0;
                secondPerson = (PersonModel) formatter.Deserialize(stream);
            }
            catch (SerializationException exception)
            {
                Console.WriteLine($"Failed to Serialize: { exception.Message }");
                throw;
            }
        }

        static void SetPersonStreetAddress(PersonModel person, string newAddress)
        {
            foreach (AddressModel address in person.Addresses)
            {
                address.StreetAddress = newAddress;
            }
        }

        static void ComparePerson(PersonModel firstPerson, PersonModel secondPerson)
        {
            Console.WriteLine($"\n{ firstPerson.FirstName } != { secondPerson.FirstName }");
            Console.WriteLine($"{ firstPerson.LastName } == { secondPerson.LastName }");
            Console.WriteLine($"{ firstPerson.DateOfBirth.ToShortDateString() } == { secondPerson.DateOfBirth.ToShortDateString() }");
            Console.WriteLine($"{ firstPerson.Addresses[0].StreetAddress } != { secondPerson.Addresses[0].StreetAddress }");
            Console.WriteLine($"{ firstPerson.Addresses[0].City } == { secondPerson.Addresses[0].City }");
            Console.WriteLine($"{ firstPerson.Addresses[1].StreetAddress } != { secondPerson.Addresses[1].StreetAddress }");
            Console.WriteLine($"{ firstPerson.Addresses[1].City } == { secondPerson.Addresses[1].City }");
        }
    }

    [Serializable]
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();
    }

    [Serializable]
    public class AddressModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
