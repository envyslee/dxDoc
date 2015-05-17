using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
   public class vaccineDetail
    {

        [JsonProperty]
       public vaccineDetailSec Data { get; set; }

        [JsonProperty]
        public bool Success { get; set; }
    }
}
