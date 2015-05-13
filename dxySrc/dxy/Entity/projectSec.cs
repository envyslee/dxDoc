using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class projectSec
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Desc { get; set; }

        [JsonProperty]
        public string Cover_small { get; set; }

        [JsonProperty]
        public string Cover { get; set; }

        [JsonProperty]
        public string Type { get; set; }

        [JsonProperty]
        public string Type_name { get; set; }

        [JsonProperty]
        public string Create_time { get; set; }

        [JsonProperty]
        public string Modify_time { get; set; }


    }
}
