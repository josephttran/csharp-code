using System;

namespace ConsoleUI
{
    class Person
    {
        public DateTime Birthday { get; set; }

        public int AgeInYears
        {
            get
            {
                return Convert.ToInt32(DateTime.Now.Subtract(Birthday).TotalDays) / 365;
            }
        }

        public int AgeInMonths
        {
            get
            {
                return CalculateAgeInMonths();
            }
        }

        public int AgeInDays
        {
            get
            {
                return Convert.ToInt32(DateTime.Now.Subtract(Birthday).TotalDays);
            }
        }

        public Person(DateTime birthday)
        {
            Birthday = birthday;
        }
        
        private int CalculateAgeInMonths()
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
    }
}
