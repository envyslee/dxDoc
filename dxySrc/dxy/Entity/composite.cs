using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class composite
    {
        [JsonProperty]
        public compositeSec Data { get; set; }

        [JsonProperty]
        public string Success { get; set; }

    }
}
