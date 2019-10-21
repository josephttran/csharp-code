using NUnit.Framework;
using RentalCostLibrary;

namespace RentalCostTests
{
    class RentCostTest
    {
        [TestCase(25, 1, 5)]
        [TestCase(75, 1, 15)]
        [TestCase(175, 4, 0)]
        [TestCase(225, 4, 15)]
        public void TestBasicRentalCost(int expected, int hours, int minutes)
        {
            Rent rent = new Rent
            {
                AdditionalCostPerHours = 50.00m,
                FirstCostPerNumberMinutes = (25.00m, 60),
                MinutesConsideredAnHour = 10
            };

            Assert.AreEqual(expected, RentCost.CalculateRentalCost(rent, (hours, minutes)));
        }

        [TestCase(5, 0, 30)]
        [TestCase(55, 0, 31)]
        [TestCase(55, 1, 30)]
        [TestCase(105, 1, 31)]
        public void TestRentalCostAnotherRent(int expected, int hours, int minutes)
        {
            Rent rent = new Rent
            {
                AdditionalCostPerHours = 50.00m,
                FirstCostPerNumberMinutes = (5.00m, 20),
                MinutesConsideredAnHour = 10
            };

            Assert.AreEqual(expected, RentCost.CalculateRentalCost(rent, (hours, minutes)));
        }
    }
}
