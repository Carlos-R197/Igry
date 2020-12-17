using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class ParentPlatform
    {

        [JsonProperty("platform")]
        public Platform Platform { get; set; }
    }
}
