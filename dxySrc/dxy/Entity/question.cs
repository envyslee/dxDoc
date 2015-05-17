using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class question
    {
        [JsonProperty]
        public int Current_item_count { get; set; }


        [JsonProperty]
        public List<questionSec> Items { get; set; }
    }
}
