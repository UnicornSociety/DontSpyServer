using System;
using System.Threading.Tasks;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;

namespace ModernEncryption.Service
{
    internal class UserService : IUserService
    {
        public async Task<User> GetUser(string eMail)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> NewUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
