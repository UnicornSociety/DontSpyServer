using System;
using System.Globalization;
using ModernEncryption.Translations;
using ModernEncryption.Utils;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.Converter
{
    internal class TimestampConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueDateTime = TimeManagement.UnixTimestampToDateTime((int)value);

            // If it is today, only output the time
            if (valueDateTime.Date == TimeManagement.UnixTimestampToDateTime(TimeManagement.UnixTimestampNow).Date)
                return valueDateTime.ToLocalTime().ToString("t", culture);

            // If it is yesterday, do not output full day date
            if (TimeManagement.UnixTimestampToDateTime(TimeManagement.UnixTimestampNow) - valueDateTime ==
                TimeSpan.FromDays(1))
                return AppResources.Yesterday + " " + valueDateTime.ToLocalTime().ToString("t", culture);


            return valueDateTime.ToLocalTime().ToString("g", culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
