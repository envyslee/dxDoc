﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace dxy.Entity
{
    public class news
    {
        [JsonProperty]
        public string Page_index { get; set; }
     

        [JsonProperty]
        public List<newsSec> Items { get; set; }
    }
}
