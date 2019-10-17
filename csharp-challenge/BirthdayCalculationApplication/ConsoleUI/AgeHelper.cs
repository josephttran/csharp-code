using System;

namespace ConsoleUI
{
    static class AgeHelper
    {
        public static int CalculateAgeInDays(DateTime birthday)
        {
            return Convert.ToInt32(DateTime.Now.Subtract(birthday).TotalDays - 1);
        }

        public static int CalculateAgeInMonths(DateTime birthday)
        {
            DateTime dateNow = DateTime.Now;
            DateTime tempDate = birthday;
            int months = 0;

            if (birthday.Year == dateNow.Year)
            {
                return dateNow.Month - birthday.Month;
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

        public static int CalculateAgeInYears(DateTime birthday)
        {
            return Convert.ToInt32(DateTime.Now.Subtract(birthday).TotalDays - 1) / 365;
        }
    }
}
