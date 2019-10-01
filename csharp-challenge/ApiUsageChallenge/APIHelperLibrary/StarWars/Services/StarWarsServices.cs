using System;
using System.Net.Http;

namespace APIHelperLibrary.StarWars.Services
{
    public class StarWarsServices: IStarWars
    {
        public HttpClient HttpClient { get; set; } = new HttpClient();

        public string BaseUri { get; set; } = "https://swapi.co/api/";

        public StarWarsServices()
        {
            HttpClient.BaseAddress = new Uri(BaseUri);
        }
    }
}
