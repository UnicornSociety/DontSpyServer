using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ModernEncryption.Interfaces;
using System.Threading;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using ModernEncryption.Presentation.ViewModel;
using Plugin.SecureStorage;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace ModernEncryption.Service
{
    internal class RequestorService : IRequestorService
    {
        private readonly IMessageService _messageService;
        private SQLiteConnection Database { get; } = DependencyService.Get<IStorage>().GetConnection();


        public RequestorService()
        {
            _messageService = new MessageService();
        }

        public async void Start()
        {
            var userId = CrossSecureStorage.Current.GetValue("userId");
            PullMessagesByUserId(int.Parse(userId)); // TODO: Call every X seconds
            Channel[] channels = {};
            var app= new App(true);
            for (int i = 0; i < app.AllChannels.Length; i++) {
                channels[i] = app.AllChannels[i];
            }
            PullMessagesByExistingChannel(channels); // TODO: Call every X seconds
        }

        /* Messages with channelId == userId are new PullRequests */
        private void PullMessagesByUserId(int userId)
        {
            foreach (var message in _messageService.GetMessage(userId).Result)
            {
                var senderSplit = message.Sender.Split(';');
                var sender = senderSplit[0];
                var channelId = int.Parse(senderSplit[1]);
                var groupIndicator = senderSplit[2] == "true" ? Channel.GroupIndicator.Group : Channel.GroupIndicator.Single;

                var user = Database.GetWithChildren<User>(sender); // TODO: If null, add User to local database and recall to get the user
                var channel = new Channel(channelId, new List<User> { user }, groupIndicator);
                channel.Messages.Add(message);
                Database.InsertWithChildren(channel);
                var app = new App(true);
                app.AllChannels[app.AllChannels.Length + 1] = channel;
            }
        }

        private void PullMessagesByExistingChannel(Channel[] channels)
        {
            foreach (var channel in channels)
            {
                var channelId = channel.Id;
                foreach (var message in _messageService.GetMessage(channelId).Result)
                {
                    channel.Messages.Add(message);
                }
            }
        }
    }
}

