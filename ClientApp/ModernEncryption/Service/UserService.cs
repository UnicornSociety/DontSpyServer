using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ModernEncryption.Service
{
    class UserService : IUser
    {
        HttpClient client;

        public UserService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<User>> GetUserTask(int eMail)
        {
            // RestUrl = http://localhost/api/user{email}
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<List<User>>(content);
            }
            return Items;
        }

        public List<User> Items { get; set; }

        public async Task NewUser(User user, bool isNewItem = false)
        {
            // RestUrl = http://localhost/api/user/new
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await client.PostAsync(uri, content);
            }

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"User successfully saved.");

            }
        }
        /*public User GetUser(string eMail)

        {
            return true;
        }

        public bool NewUser(User user)
        {
            throw new NotImplementedException();
        }*/
    }
}
