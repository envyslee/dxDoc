using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class questionSec
    {
        [JsonProperty]
        public string Article_id { get; set; }

        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public string Id { get; set; }


        [JsonProperty]
        public List<questionThird> Answers { get; set; }
    }
}
