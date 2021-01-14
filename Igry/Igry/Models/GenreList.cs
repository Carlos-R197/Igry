using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igry.Models
{
    class GenreList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public object Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public IList<Genre> Results { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("seo_title")]
        public string SeoTitle { get; set; }

        [JsonProperty("seo_description")]
        public string SeoDescription { get; set; }

        [JsonProperty("seo_h1")]
        public string SeoH1 { get; set; }
    }
}
