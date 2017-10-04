using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ModernEncryption.Interfaces;
using System.Threading;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Model;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace ModernEncryption.Service
{
    class RequestorService : IRequestorService
    {
        private SQLiteConnection Database { get; } = DependencyService.Get<IStorage>().GetConnection();

        public async void Start()
        {
            
        }

        private void PullMessagesByUserId(int userId)
        {
            // Get from Server -> Decryption -> Output
            IMessageService messageService = new MessageService();
            var encryptedMessages = messageService.GetMessage(userId).Result;
        }

        private Channel GetChannel(Message message)
        {
            var result = Database.GetAllWithChildren<Channel>(c => c.Id == message.Channel);
            if (result.Count > 0)
            {
                return Database.GetWithChildren<Channel>(result[0]);
            }
            var senderString = message.Sender;
            var senderSplit = senderString.Split(';');
            var user = Database.GetWithChildren<User>(senderSplit[0]);
            //TODO user abspeichern wenn noch nicht da entspricht hoffentlichn null als rückgabe
            var channel = new Channel(Int32.Parse(senderSplit[1]), new List<User> { user }, Channel.GroupIndicator.Single);
            Database.InsertWithChildren(channel);
        }

        private void DecryptMessages(List<EncryptedMessage> encryptedMessages)
        {
            foreach (var message in encryptedMessages)
            {
                IDecrypt decryptionLogic = new DecryptionLogic(message);
                Debug.WriteLine(decryptionLogic.Decrypt().Text);//TODO wenns funktioniert die Zeile löschen
            }
        }
    }
}
