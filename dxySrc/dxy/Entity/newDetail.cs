using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
   public  class newDetail
    {
       [JsonProperty]
       public List<newDetailSec> Items { get; set; }
    }
}
