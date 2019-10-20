using System;

namespace TrunkRentalConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal OneHourFiveMinutes = CalculateRentalCost(1, 5);
            decimal OneHourFifteenMinutes = CalculateRentalCost(1, 15);
            decimal FourHours = CalculateRentalCost(4, 0);
            decimal FourHoursFifteenMinutes = CalculateRentalCost(4, 15);

            Console.WriteLine($"The rental cost for 1 hour 5 minutes is: { OneHourFiveMinutes }");
            Console.WriteLine($"The rental cost for 1 hour 15 minutes is: { OneHourFifteenMinutes }");
            Console.WriteLine($"The rental cost for 4 hours is: { FourHours }");
            Console.WriteLine($"The rental cost for 4 hours 15 minutes is: { FourHoursFifteenMinutes }");
        }

        static decimal CalculateRentalCost(int hours, int minutes)
        {
            decimal totalCost = 0.00m;
            decimal firstHourCost = 25.00m;
            decimal additionalHourRate = 50.00m;
            int totalMinutes = hours * 60 + minutes;

            if (totalMinutes < 11)
            {
                return totalCost;
            }

            if (totalMinutes > 10 && totalMinutes <= 70)
            {
                return firstHourCost;
            }
            else
            {
                int totalHours = hours + (minutes > 10 ? 1 : 0);
                totalCost = firstHourCost + ((totalHours - 1) * additionalHourRate);
            }

            return totalCost;
        }
    }
}
