using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace DentistApp
{
    class ConvertRow : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Patient)
            {
                if (((Patient)value).Age < 15)
                {
                    return Brushes.Green;
                }
                else
                {
                    return Brushes.Black;
                }
            }
            else
            {
                return Brushes.Black;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
