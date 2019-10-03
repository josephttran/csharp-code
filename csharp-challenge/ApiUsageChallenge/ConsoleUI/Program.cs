using System;
using System.Threading.Tasks;

using APIHelperLibrary.StarWars.Model;
using APIHelperLibrary.StarWars.Services;

namespace ConsoleUI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var starWarsPeopleServices = new StarWarsPeopleServices();
            int personId = GetIdFromInput();
            StarWarsPerson starWarsPerson = await starWarsPeopleServices.GetStarWarsPerson(personId);

            starWarsPeopleServices.ShowPrettyJson(starWarsPerson);
        }

        static int GetIdFromInput()
        {
            int id = -1;
            bool valid = false;

            while (!valid)
            {
                Console.Write("\nEnter an ID: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int inputID))
                {
                    valid = true;
                    id = inputID;
                }
                else
                {
                    Console.WriteLine("Error: Please enter a number!");
                }
            }

            return id;
        }
    }
}
