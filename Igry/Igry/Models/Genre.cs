using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class Genre : BaseModel
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
