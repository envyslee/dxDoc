using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class medicine
    {

        [JsonProperty]
        public string Count { get; set; }


        [JsonProperty]
        public List<medicineSec> Data { get; set; }
    }
}
