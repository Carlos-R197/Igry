using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class Filters
    {
        [JsonProperty("years")]
        public IList<Year> Years { get; set; }
    }
}
