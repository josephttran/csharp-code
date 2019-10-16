using System;

namespace ConsoleUI
{
    public static class AgeHelper
    {
        public static int CalculateAgeInDays(DateTime Birthday)
        {
            return Convert.ToInt32(DateTime.Now.Subtract(Birthday).TotalDays);
        }

        public static int CalculateAgeInMonths(DateTime Birthday)
        {
            DateTime dateNow = DateTime.Now;
            DateTime tempDate = Birthday;
            int months = 0;

            if (Birthday.Year == dateNow.Year)
            {
                return dateNow.Month - Birthday.Month;
            }

            while (!(tempDate.Year == dateNow.Year && tempDate.Month == dateNow.Month))
            {
                tempDate = tempDate.AddMonths(1);
                months++;
            }

            if (tempDate.Day > dateNow.Day)
            {
                months--;
            }

            return months;
        }

        public static int CalculateAgeInYears(DateTime Birthday)
        {
            return Convert.ToInt32(DateTime.Now.Subtract(Birthday).TotalDays) / 365;
        }
    }
}
