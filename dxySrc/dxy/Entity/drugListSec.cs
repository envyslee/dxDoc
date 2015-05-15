using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class drugListSec
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string ShowName { get; set; }

        [JsonProperty]
        public string Company { get; set; }

        private string yb;
        public string Yb
        {
            get { return yb; }
            set
            {
                if (yb!=value)
                {
                    yb = value;
                    if (yb=="0")
                    {
                        color = "Silver";
                    }
                    else if (yb=="1")
                    {
                        color = "LimeGreen";
                    }
                }
            }
        }

        private string color;
        public string Color {
            get { return color; }
            set
            {
                if (color!=value)
                {
                    color=value;
                }
            }
        }
    }
}
