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
            int[] channelIds = { 1, 2, 3 };//TODO channelIds von der Liste in der App Klasse holen
            /*var test = new App();
            foreach (var i in test.AllChannels)
            {
                channelIds[Int32.Parse(i)] = test.AllChannels.GetValue(Int32.Parse(i));
            }*/
            PullMessagesByExistingChannel(channelIds); // TODO: Call every X seconds
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
                
                // TODO: Add Channel to ObservableCollection of ChatOverviewPageViewModel
            }
        }

        private void PullMessagesByExistingChannel(int[] channelIds)
        {
            foreach (var channelId in channelIds)
            {
                foreach (var message in _messageService.GetMessage(channelId).Result)
                {
                    var senderSplit = message.Sender.Split(';');
                    var sender = senderSplit[0];
                    var groupIndicator = senderSplit[2] == "true" ? Channel.GroupIndicator.Group : Channel.GroupIndicator.Single;
                }
            }
            // TODO: Get all Channels from DB and pull with channelId
        }
    }
}

