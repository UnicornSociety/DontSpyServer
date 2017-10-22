using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ModernEncryption.Model;
using ModernEncryption.Utils;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.Converter
{
    internal class TimestampConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var messages = (List<Message>)value;
            if (messages.Count < 1) return ""; // If no message, do not show a timestamp
            return TimeManagement.UnixTimestampToDateTime(messages.Last().Timestamp).ToString(CultureInfo.InvariantCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
