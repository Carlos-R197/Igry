using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igry.Models
{
    public class GamesList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public IList<Game> Games { get; set; }

        [JsonProperty("seo_title")]
        public string SeoTitle { get; set; }

        [JsonProperty("seo_description")]
        public string SeoDescription { get; set; }

        [JsonProperty("seo_keywords")]
        public string SeoKeywords { get; set; }

        [JsonProperty("seo_h1")]
        public string SeoH1 { get; set; }

        [JsonProperty("noindex")]
        public bool Noindex { get; set; }

        [JsonProperty("nofollow")]
        public bool Nofollow { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("filters")]
        public Filters Filters { get; set; }

        [JsonProperty("nofollow_collections")]
        public IList<string> NofollowCollections { get; set; }
    }
}
