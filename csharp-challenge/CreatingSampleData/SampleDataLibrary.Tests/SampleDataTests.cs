using NUnit.Framework;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SampleDataLibrary.Tests
{
    [TestFixture]
    public class SampleDataTests
    {
        private readonly string[] _firstName = {
            "Krystalle",
            "Noe",
            "Babs",
            "Kyle",
            "Ludovika",
            "Clarey",
            "Marietta",
            "Pierre",
            "Morly",
            "Fredi",
            "Shamus",
            "Prent",
            "Arleen",
            "Olivero",
            "Melania"
        };

        private readonly string[] _lastName = {
            "Knightly",
            "Round",
            "Bairstow",
            "Casterot",
            "Simmons",
            "Spriggs",
            "Dunckley",
            "MacDunleavy",
            "Culbert",
            "Gregol",
            "Scutt",
            "Russam",
            "Larby",
            "Allkins",
            "Olivia"
        };

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestCreateRandomBool()
        {
            bool randomBool = SampleData.CreateRandomBoolean();

            Assert.IsTrue(randomBool | !randomBool);
        }

        [TestCase(50, 100)]
        [TestCase(-1.9, 1.9)]
        [TestCase(0.01, 0.99)]
        public void TestCreateRandomDoubleGivenMinMaxRange(double min, double max)
        {
            double randomDouble = SampleData.CreateRandomDouble(min, max);
            Console.WriteLine(randomDouble);
            Assert.IsTrue(randomDouble > min && randomDouble < max);
        }

        [TestCase(1, 100)]
        [TestCase(-1, 1)]
        [TestCase(0, 1)]
        public void TestCreateRandomIntegerGivenMinMaxRange(int min, int max)
        {
            int randomInteger = SampleData.CreateRandomInteger(min, max);

            Assert.IsTrue(randomInteger >= min && randomInteger <= max);
        }

        [Test]
        public void TestCreateRandomPhoneNumber()
        {
            string phoneNumber = SampleData.CreateRandomPhoneNumber();
            Console.WriteLine(phoneNumber);
            string pattern = @"\(\d{3}\) \d{3}-\d{4}";

            Assert.IsTrue(Regex.IsMatch(phoneNumber, pattern));
        }
        [Test]
        public void TestCreateRandomZipcode()
        {
            string zipcode = SampleData.CreateRandomZipcode();
            Console.WriteLine(zipcode);
            string pattern = @"\d{5}-\d{4}";

            Assert.IsTrue(Regex.IsMatch(zipcode, pattern));
        }

        [TestCase("(123) 123-1234")]
        [TestCase("123-45-6789")]
        [TestCase("12345-1234")]
        public void TestGenerateRandomFormatNumber(string formatPattern)
        {
            string randomFormatNumber = SampleData.GenerateRandomFormatNumber(formatPattern);
            string regexPattern = Regex.Replace(Regex.Escape(formatPattern), @"\d", "\\d"); 

            Console.WriteLine(randomFormatNumber);
            Console.WriteLine(regexPattern);

            Assert.IsTrue(Regex.IsMatch(randomFormatNumber, regexPattern));
        }

        [Test]
        public void TestGetRandomFirstName()
        {
            string firstName = SampleData.GetRandomFirstName();

            Assert.Contains(firstName, _firstName);
        }

        [Test]
        public void TestGetRandomLastName()
        {
            string lastName = SampleData.GetRandomLastName();

            Assert.Contains(lastName, _lastName);
        }

        [Test]
        public void TestCreateFullName()
        {
            string fullName = SampleData.CreateFullName();

            string[] firstLastName = fullName.Split(" ");

            Assert.That(_firstName.Contains(firstLastName[0]) && _lastName.Contains(firstLastName[1]));
        }
    }
}
