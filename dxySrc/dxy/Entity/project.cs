using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class project
    {
        [JsonProperty]
        public string Page_index { get; set; }


        [JsonProperty]
        public List<projectSec> Items { get; set; }
    }
}
