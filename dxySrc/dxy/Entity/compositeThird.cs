using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class compositeThird
    {
        [JsonProperty]
        public string ComponentName { get; set; }

        [JsonProperty]
        public string RouteId { get; set; }

        [JsonProperty]
        public string ComponentId { get; set; }
    }
}
