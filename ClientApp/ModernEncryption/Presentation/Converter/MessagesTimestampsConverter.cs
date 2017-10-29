using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ModernEncryption.Model;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.Converter
{
    internal class MessagesTimestampsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var messages = (List<Message>)value;
            if (messages.Count < 1) return ""; // If no message, do not show a timestamp
            return new TimestampConverter().Convert(messages.Last().Timestamp, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
