using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using APIHelperLibrary.StarWars.Model;

namespace APIHelperLibrary.StarWars.Services
{
    public class StarWarsPeopleServices: StarWarsServices
    {
        public StarWarsPeopleServices()
        {
            string peopleUri = BaseUri + "people/";
            HttpClient.BaseAddress = new Uri(peopleUri);
        }

        public async Task<StarWarsPerson> GetStarWarsPerson(int personId)
        {
            StarWarsPerson starWarPerson = null;

            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"{ HttpClient.BaseAddress.OriginalString }{ personId }");
                
                response.EnsureSuccessStatusCode();
                string jsonString = await response.Content.ReadAsStringAsync();
                starWarPerson = JsonSerializer.Deserialize<StarWarsPerson>(jsonString);

                Console.WriteLine($"status: { response.StatusCode }");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return starWarPerson;
        }

        public void ShowPrettyJson(StarWarsPerson starWarsPerson)
        {
            var jsonOption = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(starWarsPerson, jsonOption);
            Console.WriteLine();
            Console.WriteLine(json);
        }
    }
}
