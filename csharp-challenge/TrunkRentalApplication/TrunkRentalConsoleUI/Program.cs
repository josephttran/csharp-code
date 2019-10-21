using System;
using RentalCostLibrary;

namespace TrunkRentalConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Rent rent = new Rent
            {
                AdditionalCostPerHours = 50.00m,
                FirstCostPerNumberMinutes = (25.00m, 60),
                MinutesConsideredAnHour = 10
            };

            (int totalHours, int minutes) firstRental = (1, 5);
            (int totalHours, int minutes) secondRental = (1, 15);
            (int totalHours, int minutes) thirdRental = (4, 0);
            (int totalHours, int minutes) fourthRental = (4, 15);

            decimal OneHourFiveMinutesCost = RentCost.CalculateRentalCost(rent, firstRental);
            decimal OneHourFifteenMinutesCost = RentCost.CalculateRentalCost(rent, secondRental);
            decimal FourHoursCost = RentCost.CalculateRentalCost(rent, thirdRental);
            decimal FourHoursFifteenMinutesCost = RentCost.CalculateRentalCost(rent, fourthRental);

            Console.WriteLine("Rent One");
            DisplayRentalCost(firstRental, OneHourFiveMinutesCost);
            DisplayRentalCost(secondRental, OneHourFifteenMinutesCost);
            DisplayRentalCost(thirdRental, FourHoursCost);
            DisplayRentalCost(fourthRental, FourHoursFifteenMinutesCost);

            Rent rentTwo = new Rent
            {
                AdditionalCostPerHours = 50.00m,
                FirstCostPerNumberMinutes = (5.00m, 20),
                MinutesConsideredAnHour = 10
            };

            (int totalHours, int minutes) firstRentalTwo = (0, 30);
            (int totalHours, int minutes) secondRentalTwo = (0, 31);
            (int totalHours, int minutes) thirdRentalTwo = (1, 30);
            (int totalHours, int minutes) fourthRentalTwo = (1, 31);

            decimal ThirtyMinuteMinutesCostTwo = RentCost.CalculateRentalCost(rentTwo, firstRentalTwo);
            decimal ThirtyMinuteOneMinutesCostTwo = RentCost.CalculateRentalCost(rentTwo, secondRentalTwo);
            decimal OneHourThirtyMinuteCostTwo = RentCost.CalculateRentalCost(rentTwo, thirdRentalTwo);
            decimal OneHourThirtyOneMinuteCostTwo = RentCost.CalculateRentalCost(rentTwo, fourthRentalTwo);

            Console.WriteLine("\nRent Two");
            DisplayRentalCost(firstRentalTwo, ThirtyMinuteMinutesCostTwo);
            DisplayRentalCost(secondRentalTwo, ThirtyMinuteOneMinutesCostTwo);
            DisplayRentalCost(thirdRentalTwo, OneHourThirtyMinuteCostTwo);
            DisplayRentalCost(fourthRentalTwo, OneHourThirtyOneMinuteCostTwo);
        }

        static void DisplayRentalCost((int hours, int minutes) rental, decimal cost)
        {
            Console.WriteLine($"The rental cost for { rental.hours } hour { rental.minutes } minutes is: { cost }");
        }
    }
}