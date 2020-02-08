using NUnit.Framework;
using System;
using System.Linq;

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
            var randomBool = SampleData.CreateRandomBoolean();

            if (randomBool == true || randomBool == false)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestCase(1, 100)]
        [TestCase(-1, 1)]
        [TestCase(0, 1)]
        public void TestCreateRandomIntegerGivenMinMaxRange(int min, int max)
        {
            var randomInteger = SampleData.CreateRandomInteger(min, max);

            Assert.IsTrue(randomInteger >= min && randomInteger <= max);
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
