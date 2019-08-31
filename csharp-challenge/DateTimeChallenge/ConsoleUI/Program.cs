using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\nGive me a date: ");
            DateTime date = GetDateInput();
            DisplayNumDaySinceDate(date);

            Console.Write("\nGive me a time: ");
            DateTime time = GetTimeInput();
            DisplayHourMinuteSinceTime(time);

            Console.ReadLine();
        }

        static DateTime GetDateInput()
        {
            DateTime date = new DateTime();
            string dateString = Console.ReadLine();

            if (DateTime.TryParse(dateString, out DateTime dateValue))
            {
                date = dateValue;
            }
            else
            {
                Console.WriteLine($"Error: '{ dateString }' is not a date.");
                Console.WriteLine($"The date input is set to { date }.");
            }

            return date;
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

        static void DisplayNumDaySinceDate(DateTime date)
        {
            Console.WriteLine(
                $"It has been { DateTime.Now.Subtract(date).Days } " +
                $"{ (DateTime.Now.Subtract(date).Days > 1 ? "days" : "day") } " +
                $"since { date.ToShortDateString() }");
        }

        static void DisplayHourMinuteSinceTime(DateTime time)
        {
            Console.WriteLine(
                $"{ time.ToShortTimeString() } was { DateTime.Now.Subtract(time).Hours } hours " +
                $"and { DateTime.Now.Subtract(time).Minutes } minutes ago");
        }
    }
}
