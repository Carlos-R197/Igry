using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class PlatformData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("image")]
        public object Image { get; set; }

        [JsonProperty("year_end")]
        public object YearEnd { get; set; }

        [JsonProperty("year_start")]
        public int? YearStart { get; set; }

        [JsonProperty("games_count")]
        public int GamesCount { get; set; }

        [JsonProperty("image_background")]
        public string ImageBackground { get; set; }
    }
}
