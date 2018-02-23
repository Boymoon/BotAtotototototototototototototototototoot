using Ar_Helper.OrderCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Ar_Helper
{
    /// <summary>
    /// converter for Order Section.
    /// </summary>
    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((StagesOfOrder)value)
            {
                case StagesOfOrder.Canceled:
                    {
                        return StagesOfOrder.Canceled;
                    }
                case StagesOfOrder.OnDelivered:
                    {
                        return StagesOfOrder.Canceled;
                    }
                case StagesOfOrder.OnDeleted:
                    {
                        return StagesOfOrder.Canceled;
                    }
                case StagesOfOrder.OnProgress:
                    {
                        return StagesOfOrder.Canceled;
                    }
                default:
                    return StagesOfOrder.None;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
