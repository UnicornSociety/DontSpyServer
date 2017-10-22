using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ModernEncryption.Model;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.Converter
{
    internal class MessageSnippetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var messages = (List<Message>)value;
            if (messages.Count < 1) return ""; // If no messages, do not show a snippet
            var messageToBeSnip = messages.Last().Text;
            if (messageToBeSnip.Length > 10) return messages.Last().Text.Substring(0, 10) + " ...";
            return messageToBeSnip + " ...";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
