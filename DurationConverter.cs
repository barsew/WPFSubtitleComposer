using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace lab_pkt2
{
    public class DurationConverter : IMultiValueConverter
    {
        private TimeSpan showTime;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2 || values == null || values[0].GetType() != typeof(TimeSpan) || values[1].GetType() != typeof(TimeSpan))
            {
                return null;
            }
            showTime = (TimeSpan)values[1];
            //TimeSpan ret = (TimeSpan)values[0] - (TimeSpan)values[1];

            TimeSpan span = (TimeSpan)values[0] - (TimeSpan)values[1];
            return TmeSpanConverter.TStoString(span);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            try
            {
                string s = (string)value;
                (TimeSpan duration, bool isConversionOk) = TmeSpanConverter.StringToTS(s, culture);
                TimeSpan span = default;

                if(isConversionOk == false)
                {
                    return (object[])DependencyProperty.UnsetValue;
                }

                span = duration + showTime;
                return new object[] { span };
            }
            catch { };
            return null;
        }

    }
}
