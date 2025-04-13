using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TimeObserver.Converters {
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter {
        public bool Invert { get; set; }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            bool v = (bool)value;

            if (Invert) v = !v;

            return v ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return (Visibility)value switch { 
                Visibility.Visible => true,
                _ => false,
            };
        }
    }
}
