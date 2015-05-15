using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class compositeSec
    {
        [JsonProperty]
        public string Definition { get; set; }

        [JsonProperty]
        public string CnName { get; set; }

        [JsonProperty]
        public string EntryCn { get; set; }


        [JsonProperty]
        public List<compositeThird> Components { get; set; }


        [JsonProperty]
        public string Therapy { get; set; }
    }
}
