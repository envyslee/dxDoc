using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class drug
    {

        [JsonProperty]
        public bool Success { get; set; }


    

        [JsonProperty]
        public drugSec Data { get; set; }

    }
}
