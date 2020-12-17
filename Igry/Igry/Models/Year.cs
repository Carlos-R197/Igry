using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class Year
    {
        [JsonProperty("from")]
        public int From { get; set; }

        [JsonProperty("to")]
        public int To { get; set; }

        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("decade")]
        public int Decade { get; set; }

        [JsonProperty("years")]
        public IList<Date> Dates { get; set; }

        [JsonProperty("nofollow")]
        public bool Nofollow { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

}
