using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace WhereAmI.Common
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }

            if (!(value is DateTime))
            {
                throw new ArgumentException("Value must be of type DateTime.", "value");
            }

            DateTime currentDate = (DateTime)value;
            string currentParameter = parameter as string;

            if (string.IsNullOrWhiteSpace(currentParameter))
            {
                // Date "7/27/2011 9:30:59 AM" returns "July 27, 2011"
                return currentDate.ToString("MMMMMMM dd, yyyy");
            }

            if (currentParameter == "shortDate")
            {
                return currentDate.ToString("MMM dd");
            }

            if (currentParameter == "shortYear")
            {
                return currentDate.ToString("yy");
            }

            if (currentParameter == "time")
            {
                return currentDate.ToString("HH:mm");
            }

            return currentDate.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string strValue = value as string;
            DateTime resultDateTime;
            if (DateTime.TryParse(strValue, out resultDateTime))
            {
                return resultDateTime;
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
