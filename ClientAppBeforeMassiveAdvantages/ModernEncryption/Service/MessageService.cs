using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using Newtonsoft.Json;

namespace ModernEncryption.Service
{
    internal class MessageService : IMessageService
    {

        public async Task<List<EncryptedMessage>> GetMessage(int channelId)
        {
            var items = new List<EncryptedMessage>();

            var uri = new Uri(string.Format(Constants.RestUrlGetMessage, channelId));
            var response = await _client.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<EncryptedMessage>>(content);
            }

            return items;
        }
    }
}

