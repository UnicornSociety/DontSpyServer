using System;
using System.Collections.Generic;
using System.Text;
using ModernEncryption.Model;

namespace ModernEncryption.Interfaces
{
    interface IMessage
    {
        Message GetMessage(int userId);
        bool SendMessage(Message message);

    }
}
