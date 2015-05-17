using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Entity
{
    public class vaccineDetailSec
    {
        private string contraindications;
        public string Contraindications
        {
            get { return contraindications; }
            set
            {
                if (contraindications!=value)
                {
                    contraindications = value;
                    if (contraindications.Contains("<br/>"))
                    {
                        contraindications = contraindications.Replace("<br/>", "");
                    }
                }
            }
        }//禁忌

        [JsonProperty]
        public string ArticleIds { get; set; }

        [JsonProperty]
        public string AliasName { get; set; }//名称

        [JsonProperty]
        public string InjectionNumber { get; set; }//接种剂次

        [JsonProperty]
        public string Effect { get; set; }//预防疾病

        private string precautions;
        public string Precautions
        {
            get { return precautions; }
            set
            {
                if (precautions!=value)
                {
                    precautions = value;
                    if (precautions.Contains("<br/>"))
                    {
                       precautions= precautions.Replace("<br/>", "");
                    }
                }
            }
        }//注意事项

        private string vaccination;
        public string Vaccination
        {
            get { return vaccination; }
            set
            {
                if (vaccination!=value)
                {
                    vaccination = value;
                    if (vaccination.Contains("<br/>"))
                    {
                        vaccination = vaccination.Replace("<br/>", "");
                    }
                }
            }
        }//接种对象

        private string introduction;
        public string Introduction
        {
            get { return introduction; }
            set
            {
                if (introduction!=value)
                {
                    introduction = value;
                    if (introduction.Contains("<br/>"))
                    {
                        introduction = introduction.Replace("<br/>", "");
                    }
                }
            }
        }//提示
    }
}
