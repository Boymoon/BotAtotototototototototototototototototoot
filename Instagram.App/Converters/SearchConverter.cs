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
  public  class SearchConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (parameter)
            {
                case "BeginSearchCommand":
                    {
                        if ((string)value == "readytobegin")
                        {
                            return Visibility.Visible;
                        }
                        else if ((string)value == "readytoclose")
                        {
                            return Visibility.Collapsed;
                        }
                        else
                        {
                            return Visibility.Visible;
                        }
                    }
                case "EndSearchCommand":
                    {
                        if ((string)value == "readytobegin")
                        {
                            return Visibility.Collapsed;
                        }
                        else if ((string)value == "readytoclose")
                        {
                            return Visibility.Visible;
                        }
                        else
                        {
                            return Visibility.Collapsed;
                        }
                    }
                case "TypesOfMedia_vid":
                    if ((TypesOfMedia)value == TypesOfMedia.Video)
                    {
                        return Visibility.Visible;
                    }
                    else
                    {
                        return Visibility.Collapsed;
                    }
                case "TypesOfMedia_imgs":
                    if ((TypesOfMedia)value==TypesOfMedia.Imgs)
                    {
                        return Visibility.Visible;
                    }
                    else
                    {
                        return Visibility.Collapsed;
                    }
                case "G2":
                    return "G2";
                case "G3":
                    return "G3";
                default:
                    return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
