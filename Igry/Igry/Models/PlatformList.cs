using System;
using System.Collections.Generic;
using System.Text;

namespace Igry.Models
{
    class PlatformList
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public IList<PlatformData> Results { get; set; }
    }
}
