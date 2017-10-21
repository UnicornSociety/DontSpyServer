using System.Collections.Generic;
using System.Linq;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Rest;
using SQLiteNetExtensions.Extensions;

namespace ModernEncryption.Service
{
    internal class ChannelService : IChannelService
    {
        private RestOperations RestOperations { get; }

        public ChannelService()
        {
            RestOperations = new RestOperations();
        }

        public Channel CreateChannel(User member, string channelName = null)
        {
            return CreateChannel(new List<User> { member }, channelName);
        }

        public Channel CreateChannel(List<User> members, string channelName = null)
        {
            var channelIdentifier = 242352; // TODO!
            var channel = new Channel(channelIdentifier, members, channelName);
            DependencyManager.ChannelsPage.ViewModel.Channels.Add(channel);
            DependencyManager.Database.InsertWithChildren(channel);

            var memberList = members.Aggregate("", (current, member) => current + member.Email);
            foreach (var member in members)
            {
                var preparedMessage = new Message(DependencyManager.Me.Id.ToString() + channelIdentifier + memberList,
                    "OnBoardingMessage")
                {
                    ChannelId = member.Id // Manipulated to call pull broadcast by receiver
                };

                var result = RestOperations.SendMessage(preparedMessage).Result; // TODO: Handle in future if request is not succeeded
            }

            return channel;
        }

        public User AddUserBy(string email)
        {
            var user = RestOperations.GetUserBy(email).Result;
            if (user == null) return null;

            // Insert or replace the user (replace to refresh the maybe changed user information)
            DependencyManager.Database.InsertOrReplaceWithChildren(user);

            return user;
        }

        public List<User> LoadContacts()
        {
            return DependencyManager.Database.GetAllWithChildren<User>();
        }

        public List<Channel> LoadChannels()
        {
            return DependencyManager.Database.GetAllWithChildren<Channel>();
        }

        public bool SendMessage(string message, Channel channel)
        {
            var preparedMessage = new Message(DependencyManager.Me.Id.ToString(), message);
            channel.View.ViewModel.Messages.Add(preparedMessage);
            channel.Messages.Add(preparedMessage);
            DependencyManager.Database.UpdateWithChildren(channel);

            return RestOperations.SendMessage(preparedMessage).Result;
        }

        public List<Channel> PullNewMessages()
        {
            var channels = new List<Channel>();
            foreach (var channel in DependencyManager.ChannelsPage.ViewModel.Channels)
            {
                foreach (var message in RestOperations.GetMessageBy(channel.Id).Result)
                {
                    channel.View.ViewModel.Messages.Add(message);
                    channel.Messages.Add(message);
                    DependencyManager.Database.UpdateWithChildren(channel);
                }

                channels.Add(channel);
            }
            return channels;
        }

        public List<Channel> PullChannelRequests()
        {
            var channels = new List<Channel>();
            foreach (var message in RestOperations.GetMessageBy(DependencyManager.Me.Id).Result)
            {
                var receivingChannelSplit = message.MessageHeader.Split(';');
                var sender = receivingChannelSplit[0];
                var newChannelIdentifier = receivingChannelSplit[1];

                var members = new List<User>();
                for (var i = 2; i < receivingChannelSplit.Length; i++)
                {
                    var member = AddUserBy(receivingChannelSplit[i]);
                    if (member == null) continue;
                    members.Add(member);
                }

                var channel = new Channel(int.Parse(newChannelIdentifier), members);
                channel.Messages.Add(new Message(sender, message.Text) { Timestamp = message.Timestamp });
                DependencyManager.ChannelsPage.ViewModel.Channels.Add(channel);
                DependencyManager.Database.InsertWithChildren(channel);

                channels.Add(channel);
            }
            return channels;
        }
    }
}
