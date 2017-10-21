using System.Collections.Generic;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using Plugin.SecureStorage;
using SQLiteNetExtensions.Extensions;

namespace ModernEncryption.Service
{
    internal class RequestorService
    {



        public async void Start()
        {
            var userId = CrossSecureStorage.Current.GetValue("userId");
            // PullMessagesByUserId(int.Parse(userId)); // TODO: Call every X seconds
            /* TODO Channel[] channels = {};
            var app= new App(true);
            for (int i = 0; i < app.AllChannels.Length; i++) {
                channels[i] = app.AllChannels[i];
            }*/
            // PullMessagesByExistingChannel(channels); // TODO: Call every X seconds
        }

        /* Messages with channelId == userId are new PullRequests */
        private void PullMessagesByUserId(int userId)
        {
            foreach (var message in _messageService.GetMessage(userId).Result)
            {
                
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

