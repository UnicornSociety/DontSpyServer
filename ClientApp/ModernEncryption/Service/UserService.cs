using System;
using System.Net.Http;
using System.Threading.Tasks;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using Newtonsoft.Json;

namespace ModernEncryption.Service
{
    internal class UserService : IUserService
    {
        private readonly HttpClient _client;

        public UserService()
        {
            _client = new HttpClient {MaxResponseContentBufferSize = 256000};
        }

        public async Task<User> GetUser(string eMail)
        {
            var uri = new Uri(string.Format(RestConstants.RestUrlGetUser, eMail));
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);
            }
            return null;

            async Task<bool> NewUser(User user)
            {
                throw new NotImplementedException();
            }
        }

        public Task<bool> NewUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
