﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class RequirementsEn
    {

        [JsonProperty("minimum")]
        public string Minimum { get; set; }

        [JsonProperty("recommended")]
        public string Recommended { get; set; }
    }
}
