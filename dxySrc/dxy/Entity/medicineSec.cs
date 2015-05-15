using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class medicineSec
    {
        [JsonProperty]
        public string Cf { get; set; }

        [JsonProperty]
        public string CnName { get; set; }

        [JsonProperty]
        public string Company { get; set; }

        [JsonProperty]
        public string CreatDate{ get; set; }

        [JsonProperty]
        public string DrugId { get; set; }

        [JsonProperty]
        public string EngName { get; set; }

        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string ShowName { get; set; }

        [JsonProperty]
        public string Type { get; set; }

        [JsonProperty]
        public string VsName { get; set; }

        [JsonProperty]
        public string Yb { get; set; }
    }
}
