using System;
using System.Globalization;
using System.Windows.Data;

namespace MusicPlayer.UI.Converters
{
    class ArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueArray = IsValidStringArray(value) ? (string[])value : null;
            var parameterString = IsValidString(parameter) ? (string)parameter : null;

            if(valueArray != null)
            {
                return parameterString == null ? string.Join(" ", valueArray) : string.Join(parameterString, valueArray);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;

        private bool IsValidStringArray(object value)
            => value != null && value.GetType() == typeof(string[]);

        private bool IsValidString(object value)
            => value != null && value.GetType() == typeof(string);
    }
}
