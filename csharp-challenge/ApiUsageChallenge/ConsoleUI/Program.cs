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
            int personId = 2;
            StarWarsPerson starWarsPerson = await starWarsPeopleServices.GetStarWarsPerson(personId);

            starWarsPeopleServices.ShowPrettyJson(starWarsPerson);
        }
    }
}
