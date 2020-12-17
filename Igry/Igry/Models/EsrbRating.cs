using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class EsrbRating
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}
