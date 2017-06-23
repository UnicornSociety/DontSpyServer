using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;

namespace ModernEncryption.Service
{
    class MessageService : IMessage
    {
        public Message GetMessage(int userId)
        {
            Debug.WriteLine("Bitte Eingabe taetigen: ");
            return null;
        }

        public bool SendMessage( Message message)
        {
            throw new NotImplementedException();
        }
    }
}
