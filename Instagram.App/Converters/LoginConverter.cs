using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Instagram.App
{
    /// <summary>
    /// محول للقيم الى قيم يمكن التعامل معها عبر xaml
    /// </summary>
    public class LoginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            /*  متعددة الاستخدامات */
            if ((string)parameter == "Login")
            {
                switch (value)
                {
                    case true:
                        return Visibility.Collapsed;
                    case false:
                        return Visibility.Visible;
                    default:
                        return Visibility.Collapsed;
                }
            }
            /*  متعددة الاستخدامات */
            else if ((string)parameter=="other")
            {
                switch (value)
                {
                    case true:
                        return Visibility.Visible;
                    case false:
                        return Visibility.Collapsed;
                    default:
                        return Visibility.Collapsed;
                }
            }
            else if ((string)parameter == "Follow")
            {
                switch (value)
                {
                    case TypeOfResponse.Follow:
                        return Visibility.Visible;
                    case TypeOfResponse.Following:
                        return Visibility.Collapsed;
                    default:
                        return Visibility.Collapsed;
                }
            }
            else if ((string)parameter == "Following")
            {
                switch (value)
                {
                    case TypeOfResponse.Follow:
                        return Visibility.Collapsed;
                    case TypeOfResponse.Following:
                        return Visibility.Visible;
                    default:
                        return Visibility.Collapsed;
                }
            }
            else if ((string)parameter == "Requested")
            {
                switch (value)
                {
                    case TypeOfResponse.Follow:
                        return Visibility.Collapsed;
                    case TypeOfResponse.Requested:
                        return Visibility.Visible;
                    default:
                        return Visibility.Collapsed;
                }
            }
            else
            {
                switch (value)
                {
                    case TypeOfResponse.Follow:
                        return Visibility.Collapsed;
                    case TypeOfResponse.None:
                        return Visibility.Visible;
                    default:
                        return Visibility.Collapsed;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
