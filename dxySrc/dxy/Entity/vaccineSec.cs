using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
   public  class vaccineSec
    {
       [JsonProperty]
       public string AliasName { get; set; }

       [JsonProperty]
       public string Id { get; set; }

       [JsonProperty]
       public string Months { get; set; }

       private string effect;
       public string Effect
       {
           get { return effect; }
           set
           {
               if (effect!=value)
               {
                   
                   effect = value;
                   if (effect.Length>24)
                   {
                       effect = effect.Substring(0, 24) + "...";
                   }
               }
           }
       }

       [JsonProperty]
       public string InjectionNumber { get; set; }

       [JsonProperty]
       public string Name { get; set; }

       //是否收费 1免费 2收费 3免费/收费
       [JsonProperty]
       public string FeeType { get; set; }

       [JsonProperty]
       public string SameNameRelationIds { get; set; }

       [JsonProperty]
       public string MutexRelationIds { get; set; }

       //1必打 2推荐 3可选
       [JsonProperty]
       public string RecommendType { get; set; }
    }
}
