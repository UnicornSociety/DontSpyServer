using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Translations;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.Converter
{
    internal class MessageSnippetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var messages = (List<Message>)value;
            if (messages.Count < 1) return ""; // If no messages, do not show a snippet
            IDecrypt decryption = new DecryptionLogic(messages.Last());
            var messageToBeSnip = decryption.Decrypt().Text;
            if (messageToBeSnip.Length > 10) return messages.Last().Text.Substring(0, 10) + AppResources.MessageSnippetMoreSign;
            return messageToBeSnip;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
