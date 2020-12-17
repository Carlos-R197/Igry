using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class Platform
    {

        [JsonProperty("platform")]
        public PlatformData PlatformData { get; set; }

        [JsonProperty("released_at")]
        public string ReleasedAt { get; set; }

        [JsonProperty("requirements_en")]
        public RequirementsEn RequirementsEn { get; set; }

        [JsonProperty("requirements_ru")]
        public RequirementsRu RequirementsRu { get; set; }
    }
}
