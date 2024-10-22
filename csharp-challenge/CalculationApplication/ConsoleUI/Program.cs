﻿using System;

using TemperatureLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Temperature temperature = new Temperature();

            // Insert 100 random between 1 and 100 inclusive
            for (int i = 0; i < 100; i++)
            {
                int randomTemperature = random.Next(1, 101);

                temperature.Insert(randomTemperature);
            }

            temperature.Insert("ten");
            temperature.Insert("two");
            temperature.Insert("four");
            temperature.Insert("eight");

            Console.WriteLine("Temperature minimum: " + temperature.Minimum);
            Console.WriteLine("Temperature maximum: " + temperature.Maximum);
            Console.WriteLine("Temperature average: " + temperature.Average);
            Console.WriteLine();
            Console.WriteLine("List of temperatures: ");
            Console.WriteLine(String.Join(", ", temperature.Temperatures.ToArray()));
        }
    }
}
