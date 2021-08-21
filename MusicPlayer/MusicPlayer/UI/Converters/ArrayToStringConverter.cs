using System;
using System.Globalization;
using System.Windows.Data;

namespace MusicPlayer.UI.Converters
{
    class ArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!IsValidStringArray(value))
            {
                return "";
            }

            var parameterString = IsValidString(parameter) ? (string)parameter : "";
            return $"{parameterString} {string.Join(",", (string[])value)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;

        private bool IsValidStringArray(object value)
            => value != null && value.GetType() == typeof(string[]);

        private bool IsValidString(object value)
            => value != null && value.GetType() == typeof(string);
    }
}
