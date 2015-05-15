using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class drugList
    {
        [JsonProperty]
        public string UserProvince { get; set; }


        [JsonProperty]
        public List<drugListSec> Data { get; set; }
    }
}
