﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dxy.Entity
{
    public class newsSec
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public string Cover { get; set; }

        [JsonProperty]
        public string Cover_small { get; set; }

        [JsonProperty]
        public string Author_id { get; set; }

        [JsonProperty]
        public string Author { get; set; }

        [JsonProperty]
        public string Author_url { get; set; }

        [JsonProperty]
        public string Author_avatar { get; set; }

        [JsonProperty]
        public string Publish_time { get; set; }


        [JsonProperty]
        public string Special_id { get; set; }

        [JsonProperty]
        public string Special_name { get; set; }

        [JsonProperty]
        public string Author_remarks { get; set; }

    }
}
