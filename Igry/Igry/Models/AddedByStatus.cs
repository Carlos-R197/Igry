using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class AddedByStatus
    {

        [JsonProperty("yet")]
        public int Yet { get; set; }

        [JsonProperty("owned")]
        public int Owned { get; set; }

        [JsonProperty("beaten")]
        public int Beaten { get; set; }

        [JsonProperty("toplay")]
        public int Toplay { get; set; }

        [JsonProperty("dropped")]
        public int Dropped { get; set; }

        [JsonProperty("playing")]
        public int Playing { get; set; }
    }
}
