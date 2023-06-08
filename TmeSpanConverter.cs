using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;

namespace lab_pkt2
{
    public class TmeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return null;
            }

            TimeSpan span = (TimeSpan)value;
            return TStoString(span);
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ret = StringToTS((string)value, culture);
            if(ret.Item2 == false)
            {
                return DependencyProperty.UnsetValue;
            }    
     
            return ret.Item1;

        }

        public static (TimeSpan, bool) StringToTS(string s, CultureInfo culture)
        {
            TimeSpan span = default;
            if(TimeSpan.TryParseExact(s, new string[] {"mm\\:s" ,"hh\\:mm\\:s\\.f", "hh\\:mm\\:s\\.ff", "h\\:m\\:s\\.f", "h\\:m\\:s\\.ff", "h\\:mm\\:ss", "hh\\:m\\:ss", "h\\:m\\:s\\.fff", "hh\\:m\\:ss\\.fff", "h\\:m\\:ss\\.fff", "h\\:mm\\:ss\\.fff", "hh\\:mm\\:ss\\.fff", "ss\\.fff", "%s", "mm\\:ss\\:fff", "mm\\:ss", "%s\\.fff", "%s\\.f", "m\\:ss", "s\\.ff", "m\\:ss", "mm\\:s", "m\\:s" }, culture, out span) == true)
                return (span, true);
            else
                return (span, false);
        }

        public static string TStoString(TimeSpan span)
        {
            if(span == new TimeSpan(0))
            {
                return "0";
            }
            if (span.Hours > 0)
            {
                if (span.Seconds > 0 && span.Milliseconds > 0)
                {
                    return span.ToString("hh\\:mm\\:ss\\.FFF");
                }
                else if (span.Seconds > 0)
                {
                    return span.ToString("hh\\:mm\\:ss");
                }
                else if (span.Milliseconds > 0)
                {
                    return span.ToString("hh\\:mm\\:ss\\.FFF");
                }
                else
                {
                    return span.ToString("hh\\:mm");
                }
            }
            if (span.Minutes > 0)
            {
                if (span.Minutes >= 10)
                {
                    if (span.Seconds > 0 && span.Milliseconds > 0)
                    {
                        return span.ToString("mm\\:ss\\.FFF");
                    }
                    else if (span.Seconds > 0)
                    {
                        return span.ToString("mm\\:ss");
                    }
                    else if (span.Milliseconds > 0)
                    {
                        return span.ToString("mm\\:ss\\.FFF");
                    }
                }
                else
                {
                    if (span.Seconds > 0 && span.Milliseconds > 0)
                    {
                        return span.ToString("m\\:ss\\.FFF");
                    }
                    else if (span.Seconds > 0)
                    {
                        return span.ToString("m\\:ss");
                    }
                    else if (span.Milliseconds > 0)
                    {
                        return span.ToString("m\\:ss\\.FFF");
                    }
                }
            }
            if (span.Seconds > 0)
            {
                if (span.Seconds >= 10)
                {
                    if (span.Milliseconds > 0)
                    {
                        return span.ToString("ss\\.FFF");

                    }
                    else
                    {
                        return span.ToString("ss");
                    }
                }
                else
                {
                    if (span.Milliseconds > 0)
                    {
                        return span.ToString("s\\.FFF");

                    }
                    else
                    {
                        return span.ToString("%s");
                    }
                }
            }
            if (span.Milliseconds > 0)
            {
                return span.ToString("s\\.FFF");
            }

            return span.ToString();
        }
    }
}
