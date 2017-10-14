﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernEncryption.BusinessLogic.UserManagement;
using ModernEncryption.DataAccess;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Plugin.SecureStorage;
using Xamarin.Forms;

namespace ModernEncryption.Service
{
    internal class UserService : IUserService
    {
        private readonly HttpClient _client;
        private SQLiteConnection Database { get; } = DependencyService.Get<IStorage>().GetConnection();

        public UserService()
        {
            _client = new HttpClient { MaxResponseContentBufferSize = 256000 };
        }

        public async Task<User> GetUser(string eMail)
        {
            var uri = new Uri(string.Format(Constants.RestUrlGetUser, eMail));
            var response = await _client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);
            }
            Debug.WriteLine("Server antwortet nicht");
            return null;
        }

        public async Task<bool> CreateUser(User user)
        {
            try
            {
                var validateEmail = GetUser(user.Email).Result;
                if (validateEmail != null) return false;
                var uri = new Uri(string.Format(Constants.RestUrlNewUser));
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);
                CrossSecureStorage.Current.SetValue("RegistrationProcess", "1");

                var voucherCode = new VoucherCode(user);
                voucherCode.SendVoucherCode();

                CrossSecureStorage.Current.SetValue("userId", user.Id.ToString());

                Database.InsertWithAllChildren(user);//stimmt des so?

                // TODO: Save user in User-Table (local db)

                return true;
            }

            catch
            {
                Debug.WriteLine("Server antwortet nicht");
                return false;
            }

        }

        public bool ValidateVoucherCode(int userVoucher)
        {
            var voucher = Convert.ToInt32(CrossSecureStorage.Current.GetValue("Voucher", "-1"));
            var voucherTimestamp = Convert.ToInt32(CrossSecureStorage.Current.GetValue("VoucherTimestamp", "-1"));
            var currentVoucherTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            if (voucherTimestamp > currentVoucherTimestamp) return false;
            if (voucher != userVoucher) return false;
            CrossSecureStorage.Current.DeleteKey("VoucherTimestamp");
            CrossSecureStorage.Current.DeleteKey("Voucher");
            return true;
        }
    }
}
