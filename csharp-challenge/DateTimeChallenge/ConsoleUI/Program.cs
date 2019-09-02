using System;
using System.Globalization;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = GetDateInput();
            string dateFormat = GetDateFormat();
            DateTime dateTime = CreateFormatDate(date, dateFormat);

            DisplayNumDaySinceDate(dateTime, dateFormat);

            Console.Write("\nGive me a time: ");
            DateTime time = GetTimeInput();
            DisplayHourMinuteSinceTime(time);

            Console.ReadLine();
        }

        static DateTime GetTimeInput()
        {
            DateTime time = new DateTime();
            string timeString = Console.ReadLine();

            if (DateTime.TryParse(timeString, out DateTime timeValue))
            {
                time = timeValue;
            }
            else
            {
                Console.WriteLine($"Error: '{ timeString }' is not a valid time input.");
                Console.WriteLine($"The time is set to { time.ToShortTimeString() }.");
            }

            return time;
        }

        static string GetDateFormat()
        {
            string monthDayYear = "MM/dd/yy";
            string dayMonthYear = "dd/MM/yy";

            DateFormatPrompt();
            int choice = GetDateFormatChoice();

            while (choice != 1 && choice != 2)
            {
                Console.WriteLine("\nInvalid choice: must be 1 or 2!");
                DateFormatPrompt();
                choice = GetDateFormatChoice();
            }

            if (choice == 1)
            {
                return monthDayYear;
            }
            else
            {
                return dayMonthYear;
            }

            void DateFormatPrompt()
            {
                Console.WriteLine("\nWhat date format you want to use: ");
                Console.WriteLine("1) MM/dd/yy");
                Console.WriteLine("2) dd/MM/yy");
                Console.Write("Enter choice: ");
            }

            int GetDateFormatChoice()
            {
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out int number))
                {
                    return number;
                }

                return -1;
            }
        }

        static string GetDateInput()
        {
            CultureInfo us = new CultureInfo("en-us", false);
            CultureInfo gb = new CultureInfo("en-gb", false);

            Console.Write("\nGive me a date in the format dd/MM/yy or MM/dd/yy: ");
            string dateString = Console.ReadLine();

            while (!IsValidDateInput())
            {
                Console.Write("\nGive me a date in the format dd/MM/yy or MM/dd/yy: ");
                dateString = Console.ReadLine();
            }

            return dateString;

            bool IsValidDateInput()
            {
                if (DateTime.TryParseExact(dateString, "MM/dd/yy", us, DateTimeStyles.None, out _))
                {
                    return true;
                }

                if (DateTime.TryParseExact(dateString, "dd/MM/yy", gb, DateTimeStyles.None, out _))
                {
                    return true;
                }

                Console.WriteLine($"'{ dateString }' is not in an acceptable format.");
                return false;
            }
        }

        static void DisplayNumDaySinceDate(DateTime date, string dateFormat)
        {
            Console.WriteLine(
                $"\nIt has been { DateTime.Now.Subtract(date).Days } " +
                $"{ (DateTime.Now.Subtract(date).Days > 1 ? "days" : "day") } " +
                $"since { date.ToString(dateFormat) }");
        }

        static void DisplayHourMinuteSinceTime(DateTime time)
        {
            Console.WriteLine(
                $"{ time.ToShortTimeString() } was { DateTime.Now.Subtract(time).Hours } hours " +
                $"and { DateTime.Now.Subtract(time).Minutes } minutes ago");
        }

        static DateTime CreateFormatDate(string dateString, string dateFormat)
        {
            DateTime dateTime = new DateTime();

            if (dateFormat == "MM/dd/yy")
            {
                if (DateTime.TryParseExact(
                    dateString, 
                    "MM/dd/yy", 
                    CultureInfo.CreateSpecificCulture("en-us"), 
                    DateTimeStyles.None, 
                    out DateTime dateTime1))
                {
                    return dateTime1;
                }
            }

            if (dateFormat == "dd/MM/yy")
            {
                if (DateTime.TryParseExact(
                    dateString, 
                    "dd/MM/yy", 
                    CultureInfo.CreateSpecificCulture("en-gb"), 
                    DateTimeStyles.None, 
                    out DateTime dateTime2))
                {
                    return dateTime2;
                }
            }

            Console.WriteLine("\nYour entered date and date format are not compatible!");
            Console.WriteLine($"Fallback default date { dateTime.ToShortDateString() }");
            return dateTime;
        }
    }
}
