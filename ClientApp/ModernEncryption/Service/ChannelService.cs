using System;
using System.Collections.Generic;
using System.Diagnostics;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Rest;
using Newtonsoft.Json;
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
            var channel = new Channel(2525, members, channelName);
            DependencyManager.ChannelsPage.ViewModel.Channels.Add(channel);
            DependencyManager.Database.InsertWithChildren(channel);

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
    }
}
