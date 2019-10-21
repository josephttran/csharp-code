using System;
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

        [Test]
        public void TestBonusSameDayRentalCost()
        {
            TimeSpan businessOpen = new TimeSpan(9, 0, 0);
            DateTime rentalPickupDate = new DateTime(2019, 10, 18, 9, 0, 0);
            DateTime rentalReturnDate = new DateTime(2019, 10, 18, 12, 0, 0);

            Rent rent = new Rent
            {
                AdditionalCostPerHours = 50.00m,
                FirstCostPerNumberMinutes = (5.00m, 20),
                MinutesConsideredAnHour = 10
            };

            Assert.AreEqual(155, RentCost.BonusCalculateRentalCost(rent, businessOpen, rentalPickupDate, rentalReturnDate));
        }

        [Test]
        public void TestBonusWeekdayRentalCost()
        {
            TimeSpan businessOpen = new TimeSpan(9, 0, 0);
            DateTime rentalPickupDate = new DateTime(2019, 10, 21, 9, 0, 0);
            DateTime rentalReturnDate = new DateTime(2019, 10, 24, 12, 0, 0);

            Rent rent = new Rent
            {
                AdditionalCostPerHours = 50.00m,
                FirstCostPerNumberMinutes = (5.00m, 20),
                MinutesConsideredAnHour = 10
            };

            Assert.AreEqual(1350, RentCost.BonusCalculateRentalCost(rent, businessOpen, rentalPickupDate, rentalReturnDate));
        }

        [Test]
        public void TestBonusRentalCostWithWeekend()
        {
            TimeSpan businessOpen = new TimeSpan(9, 0, 0);
            DateTime rentalPickupDate = new DateTime(2019, 10, 18, 9, 0, 0);
            DateTime rentalReturnDate = new DateTime(2019, 10, 24, 12, 0, 0);

            Rent rent = new Rent
            {
                AdditionalCostPerHours = 50.00m,
                FirstCostPerNumberMinutes = (5.00m, 20),
                MinutesConsideredAnHour = 10
            };

            Assert.AreEqual(2150, RentCost.BonusCalculateRentalCost(rent, businessOpen, rentalPickupDate, rentalReturnDate));
        }
    }
}
