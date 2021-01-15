using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igry.Models
{
    public class MetacriticPlatform
    {

        [JsonProperty("metascore")]
        public int Metascore { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("platform")]
        public Platform Platform { get; set; }
    }
}
