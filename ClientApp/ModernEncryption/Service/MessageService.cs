using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;

namespace ModernEncryption.Service
{
    class MessageService : IMessage
    {
        public MessageService()
        {
            new HttpClient {MaxResponseContentBufferSize = 256000};
        }

        public Message GetMessage(int userId)
        {
            Debug.WriteLine("Bitte Eingabe taetigen: ");
            return null;
        }

        public bool SendMessage( Message message)
        {
            return true;
        }
    }
}
