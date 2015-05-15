using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
   public  class qa
    {
        [JsonProperty]
        public string Current_item_count { get; set; }


        [JsonProperty]
        public List<qaSec> Items { get; set; }
    }
}
