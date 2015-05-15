using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
   public  class articleSec
    {
       [JsonProperty]
       public string Article_title { get; set; }


       [JsonProperty]
       public string Cover { get; set; }

       [JsonProperty]
       public string Cover_small { get; set; }

       [JsonProperty]
       public string Id { get; set; }

       [JsonProperty]
       public string Img_url { get; set; }

       [JsonProperty]
       public string search_content_hl { get; set; }

    }
}
