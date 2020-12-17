using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Igry.Models
{
    public class Store
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("store")]
        public StoreData StoreData { get; set; }
    }
}
