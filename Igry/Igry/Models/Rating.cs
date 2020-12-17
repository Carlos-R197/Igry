using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class Rating
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("percent")]
        public double Percent { get; set; }
    }
}
