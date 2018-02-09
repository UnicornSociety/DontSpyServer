using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using Plugin.SecureStorage;
using SQLiteNetExtensions.Extensions;

namespace ModernEncryption.Service
{
    internal class UserService : IUserService
    {
        private IRestService RestService { get; }

        public UserService()
        {
            RestService = new RestService();
        }

        public bool CreateOwnUser(User user)
        {
            new Task(() => { RestService.CreateOwnUser(user); }).Start(); // TODO: Handle in future if request is not succeeded

            DependencyManager.Database.Insert(user);
            CrossSecureStorage.Current.SetValue("OwnUser", user.Id);
            DependencyManager.Me = user;

            return true;
        }

        public List<User> LoadContacts()
        {
            return DependencyManager.Database.GetAllWithChildren<User>().Where(user => user.Id != DependencyManager.Me.Id).ToList();
        }

        public User AddUserBy(string username)
        {
            var user = RestService.GetUserBy(username).Result;
            if (user == null) return null;

            // Insert or replace the user (replace to refresh the maybe changed user information)
            DependencyManager.Database.InsertOrReplaceWithChildren(user);

            return user;
        }
    }
}
