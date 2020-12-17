using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class Clip
    {

        [JsonProperty("clip")]
        public string Name { get; set; }

        [JsonProperty("clips")]
        public Clips Clips { get; set; }

        [JsonProperty("video")]
        public string Video { get; set; }

        [JsonProperty("preview")]
        public string Preview { get; set; }
    }
}
