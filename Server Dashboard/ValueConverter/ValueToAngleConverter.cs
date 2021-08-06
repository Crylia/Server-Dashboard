using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Server_Dashboard {
    /// <summary>
    /// Value to angle converter
    /// </summary>
    [ValueConversion(typeof(int), typeof(double))]
    public class ValueToAngleConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (int)value * 0.01 * 360;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => (int)((double)value / 360);
    }
}
