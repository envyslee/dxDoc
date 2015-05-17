using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace dxy.Converter
{
   public class ConKey:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int fee =(int) value;
            string res = string.Empty;
            if (fee==0)
            {
                res = "出生24小时以内";
            }
            else if (fee<18)
            
            {
                res = fee + "月龄";
            }
            else
            {
                if (fee % 12==0)
                {
                    res = fee / 12 + "周岁";
                }
                else
                {
                    res = fee / 12 + "岁零" + fee % 12 + "月";
                }
            }
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
