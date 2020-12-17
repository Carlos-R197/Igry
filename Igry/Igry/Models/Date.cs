using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    
    public class Date
    {

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("nofollow")]
        public bool Nofollow { get; set; }
    }
}
