using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernEncryption.BusinessLogic.UserManagement;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using Newtonsoft.Json;
using Plugin.SecureStorage;

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
            var uri = new Uri(string.Format(Constants.RestUrlGetUser, eMail));
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);
            }
            return null;
        }

        public async Task<bool> CreateUser(User user)
        {
            var uri = new Uri(string.Format(Constants.RestUrlNewUser));
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await _client.PostAsync(uri, content);

            var voucherCode = new VoucherCode(user);
            voucherCode.SendVoucherCode();

            return true;
        }

        public bool ValidateVoucherCode(int userVoucher)
        {
            var voucher = Convert.ToInt32(CrossSecureStorage.Current.GetValue("Voucher", "-1"));
            if (voucher != userVoucher) return false;

            CrossSecureStorage.Current.DeleteKey("Voucher");
            return true;
        }
    }
}
