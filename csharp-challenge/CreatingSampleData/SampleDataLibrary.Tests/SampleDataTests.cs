using NUnit.Framework;

namespace SampleDataLibrary.Tests
{
    [TestFixture]
    public class SampleDataTests
    {
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
    }
}
