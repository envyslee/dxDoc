using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dxy.Common
{
    public static class TimeChange
    {
        public static string ToUnix(DateTime dt)
        {
            DateTime dtStart = new DateTime(1970, 1, 1);
            DateTime dtNow = DateTime.Parse(DateTime.Now.ToString());
            TimeSpan toNow = dtNow.Subtract(dtStart);
            string timeStamp = toNow.Ticks.ToString();
            timeStamp = timeStamp.Substring(0, timeStamp.Length - 7);
            return timeStamp;
        }

        public static string ToLongUnix(DateTime dt)
        {
            double timeStamp = DateTime.UtcNow.AddHours(8).Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            return timeStamp.ToString();
        }

        public static DateTime ToDateTime(string t)
        {
            DateTime dtStart = new DateTime(1970, 1, 1);
            long lTime = long.Parse(t + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime dtResult = dtStart.Add(toNow);
            return dtResult;
            //DateTime gtm = (new DateTime(1970, 1, 1)).AddSeconds(Convert.ToInt32(timeStamp)); 
        }
    }
}
