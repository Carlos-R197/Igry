using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class Clips
    {
        [JsonProperty("320")]
        public string LowRes { get; set; }

        [JsonProperty("640")]
        public string MediumRes { get; set; }

        [JsonProperty("full")]
        public string FullRes { get; set; }
    }
}
