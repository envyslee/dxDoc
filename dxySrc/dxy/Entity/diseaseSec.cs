using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
   public  class diseaseSec
    {
       [JsonProperty]
       public string Id { get; set; }

       [JsonProperty]
       public string ShowName { get; set; }
    }
}
