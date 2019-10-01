using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APIHelperLibrary.StarWars.Model
{    /*
     * https://swapi.co/api/people/schema
     * key = "required"
     */
    public class StarWarsPerson
    {
        [JsonPropertyNameAttribute("name")]
        public string Name { get; set; }

        [JsonPropertyNameAttribute("height")]
        public string Height { get; set; }

        [JsonPropertyNameAttribute("mass")]
        public string Mass { get; set; }

        [JsonPropertyNameAttribute("hair_color")]
        public string HairColor { get; set; }

        [JsonPropertyNameAttribute("skin_color")]
        public string SkinColor { get; set; }

        [JsonPropertyNameAttribute("eye_color")]
        public string EyeColor { get; set; }

        [JsonPropertyNameAttribute("birth_year")]
        public string BirthYear { get; set; }

        [JsonPropertyNameAttribute("gender")]
        public string Gender { get; set; }

        [JsonPropertyNameAttribute("homeworld")]
        public string HomeWorld { get; set; }

        [JsonPropertyNameAttribute("films")]
        public List<string> Films { get; set; }

        [JsonPropertyNameAttribute("species")]
        public List<string> Species { get; set; }

        [JsonPropertyNameAttribute("vehicles")]
        public List<string> Vehicles { get; set; }

        [JsonPropertyNameAttribute("starship")]
        public List<string> Starships { get; set; }

        [JsonPropertyNameAttribute("created")]
        public DateTime Created { get; set; }

        [JsonPropertyNameAttribute("edited")]
        public DateTime Edited { get; set; }

        [JsonPropertyNameAttribute("url")]
        public string Url { get; set; }
    }
}
