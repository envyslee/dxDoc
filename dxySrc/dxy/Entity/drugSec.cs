using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class drugSec
    {

        [JsonProperty]
        public List<drugThird> Detail { get; set; }

        [JsonProperty]
        public string CommonName { get; set; }

        [JsonProperty]
        public string RouteId { get; set; }

        [JsonProperty]
        public string Price { get; set; }

        [JsonProperty]
        public string CnName { get; set; }

        [JsonProperty]
        public string DrugId { get; set; }
    }
}
