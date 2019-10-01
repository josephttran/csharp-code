using System.Net.Http;

namespace APIHelperLibrary.StarWars.Services
{
    interface IStarWars
    {
        HttpClient HttpClient { get; set; }

        string BaseUri { get; set; }
    }
}
