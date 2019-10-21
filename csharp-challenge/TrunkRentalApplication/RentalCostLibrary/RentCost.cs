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
    }
}
