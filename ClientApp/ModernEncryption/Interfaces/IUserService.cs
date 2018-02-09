using System.Collections.Generic;
using ModernEncryption.Model;

namespace ModernEncryption.Interfaces
{
    internal interface IUserService
    {
        bool CreateOwnUser(User user);
        User AddUserBy(string username);
        List<User> LoadContacts();
    }
}
