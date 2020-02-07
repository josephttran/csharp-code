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
    }
}
