using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using Newtonsoft.Json;

namespace ModernEncryption.Service
{
    class MessageService : IMessage
    {
        HttpClient client;

        public MessageService()
        {
            client = new HttpClient ();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Message>> GetMessageTask(int userId)
        {
            // RestUrl = http://localhost/api/message{receiver}
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<List<Message>>(content);
            }
            return Items;
        }

        public List<Message> Items { get; set; }

      
        public async Task SendMessage(Message message, bool isNewItem = false)
        {
            // RestUrl = http://localhost/api/message/new
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            var json = JsonConvert.SerializeObject(message);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            if (isNewItem)
            {
                response = await client.PostAsync(uri, content);
            }

            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"Message successfully saved.");

            }
        }
        /*public Message GetMessage(int userId)
      {
          Debug.WriteLine("Bitte Eingabe taetigen: ");
          return null;


      public bool SendMessage( Message message)
      {
          return true;
      }
      }*/
    }
}
