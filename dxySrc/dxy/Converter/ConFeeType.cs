using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace dxy.Converter
{
    public class ConFeeType : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string  fee = value.ToString();
            string res = string.Empty ;
            switch (fee)
            {
                case "1":
                    res = "免费";
                    break;
                case "2":
                    res = "收费";
                    break;
                case "3":
                    res = "免费/收费";
                    break;
                default:
                    break;
            }
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
