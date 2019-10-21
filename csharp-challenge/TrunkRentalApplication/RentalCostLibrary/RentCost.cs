using System;

namespace RentalCostLibrary
{
    static public class RentCost
    {
        public static decimal CalculateRentalCost(Rent rent, in (int totalHours, int minutes) Rental)
        {
            decimal totalCost;
            int secondsInAMinute = 60;
            int totalMinutes = Rental.totalHours * secondsInAMinute + Rental.minutes;

            if (totalMinutes <= rent.FirstCostPerNumberMinutes.minutes + rent.MinutesConsideredAnHour)
            {
                return rent.FirstCostPerNumberMinutes.cost;
            }
            else
            {
                int totalAdditionalHours =
                    ((totalMinutes - rent.FirstCostPerNumberMinutes.minutes) / secondsInAMinute) +
                    ((((totalMinutes - rent.FirstCostPerNumberMinutes.minutes) % secondsInAMinute) > rent.MinutesConsideredAnHour)
                    ? 1
                    : 0);

                totalCost = rent.FirstCostPerNumberMinutes.cost + (totalAdditionalHours * rent.AdditionalCostPerHours);
            }

            return totalCost;
        }

        public static decimal BonusCalculateRentalCost(Rent rent, TimeSpan businessOpen, DateTime rentalPickupDate, DateTime rentalReturnDate)
        {
            decimal totalCost = 0;
            int secondsInAMinute = 60;
            int totalMinutes = (int) rentalReturnDate.Subtract(rentalPickupDate).TotalMinutes;

            if (rentalReturnDate.Subtract(rentalPickupDate).TotalDays < 1)
            {
                if (totalMinutes <= rent.FirstCostPerNumberMinutes.minutes + rent.MinutesConsideredAnHour)
                {
                    return rent.FirstCostPerNumberMinutes.cost;
                }
                else
                {
                    int totalAdditionalHours =
                        ((totalMinutes - rent.FirstCostPerNumberMinutes.minutes) / secondsInAMinute) +
                        ((((totalMinutes - rent.FirstCostPerNumberMinutes.minutes) % secondsInAMinute) > rent.MinutesConsideredAnHour)
                        ? 1
                        : 0);

                    totalCost = rent.FirstCostPerNumberMinutes.cost + (totalAdditionalHours * rent.AdditionalCostPerHours);
                }
            }
            else
            {
                DateTime tempDate = rentalPickupDate;

                while (tempDate.AddDays(1) < rentalReturnDate)
                {
                    if (tempDate.DayOfWeek.ToString() == "Saturday" || tempDate.DayOfWeek.ToString() == "Sunday")
                    {
                        totalCost += rent.CostPerWeekend;
                    }
                    else
                    {
                        totalCost += rent.CostPerWeekday;
                    }

                    tempDate = tempDate.AddDays(1);
                }

                totalCost += ((rentalReturnDate.Hour - businessOpen.Hours) * rent.AdditionalCostPerHours);
            }

            return totalCost;
        }
    }
}
