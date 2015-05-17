using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class drugThird
    {

        [JsonProperty]
        public string CnName { get; set; }

        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                if (_value!=value)
                {
                    _value = value;
                    if (_value.Contains("<br/>"))
                    {
                        _value = _value.Replace("<br/>", "");
                    }
                    if (_value.Contains("<sub>"))
                    {
                        _value = _value.Replace("<sub>", "");
                    }
                    if (_value.Contains("</sub>"))
                    {
                        _value = _value.Replace("</sub>", "");
                    }
                }
            }
        }

        [JsonProperty]
        public string EngName { get; set; }
    }
}
