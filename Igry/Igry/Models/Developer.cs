using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igry.Models
{
    public class Developer
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("games_count")]
        public int GamesCount { get; set; }

        [JsonProperty("image_background")]
        public string ImageBackground { get; set; }
    }
}
