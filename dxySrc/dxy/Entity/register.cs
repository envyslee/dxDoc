using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
   public  class register
    {
       [JsonProperty]
       public string Appuid { get; set; }
       [JsonProperty]
       public string Avatar { get; set; }
       [JsonProperty]
       public string Message { get; set; }
       [JsonProperty]
       public string SignKey { get; set; }
       [JsonProperty]
       public bool Success { get; set; }
       [JsonProperty]
       public string Username { get; set; }
    }
}
