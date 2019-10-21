using System;

namespace TrunkRentalConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Rent rent = new Rent
            {
                AdditionalCostPerHours = 50.00m,
                FirstCostPerNumberMinutes = (25.00m, 10),
            };

            (int totalHours, int minutes) firstRental = (1, 5);
            (int totalHours, int minutes) secondRental = (1, 15);
            (int totalHours, int minutes) thirdRental = (4, 0);
            (int totalHours, int minutes) fourthRental = (4, 15);

            decimal OneHourFiveMinutesCost = CalculateRentalCost(rent, firstRental);
            decimal OneHourFifteenMinutesCost = CalculateRentalCost(rent, secondRental);
            decimal FourHoursCost = CalculateRentalCost(rent, thirdRental);
            decimal FourHoursFifteenMinutesCost = CalculateRentalCost(rent, fourthRental);

            DisplayRentalCost(firstRental, OneHourFiveMinutesCost);
            DisplayRentalCost(secondRental, OneHourFifteenMinutesCost);
            DisplayRentalCost(thirdRental, FourHoursCost);
            DisplayRentalCost(fourthRental, FourHoursFifteenMinutesCost);
        }

        static decimal CalculateRentalCost(Rent rent, in (int totalHours, int minutes) Rental)
        {
            decimal totalCost = 0.00m;
            int totalMinutes = Rental.totalHours * 60 + Rental.minutes;

            if (totalMinutes < rent.FirstCostPerNumberMinutes.minutes)
            {
                return totalCost;
            }

            if (totalMinutes > rent.FirstCostPerNumberMinutes.minutes &&
                totalMinutes <= rent.FirstCostPerNumberMinutes.minutes + 60)
            {
                return rent.FirstCostPerNumberMinutes.cost;
            }
            else
            {
                int totalHours = Rental.totalHours + (Rental.minutes > 10 ? 1 : 0);
                totalCost = rent.FirstCostPerNumberMinutes.cost + ((totalHours - 1) * rent.AdditionalCostPerHours);
            }

            return totalCost;
        }

        static void DisplayRentalCost((int hours, int minutes) rental, decimal cost)
        {
            Console.WriteLine($"The rental cost for { rental.hours } hour { rental.minutes } minutes is: { cost }");
        }
    }
}