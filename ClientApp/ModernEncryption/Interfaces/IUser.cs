using System;
using System.Collections.Generic;
using System.Text;
using ModernEncryption.Model;

namespace ModernEncryption.Interfaces
{
    interface IUser
    {
        User GetUser(string eMail);
        bool NewUser(User user);
    }
}
