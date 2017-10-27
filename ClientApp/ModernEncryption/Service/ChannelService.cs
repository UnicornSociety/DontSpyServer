using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.BusinessLogic.UserManagement;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Rest;
using ModernEncryption.Utils;
using Plugin.SecureStorage;
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

        public bool CreateOwnUser(User user)
        {
            new Task(() => { RestOperations.CreateOwnUser(user); }).Start(); // TODO: Handle in future if request is not succeeded

            DependencyManager.Database.Insert(user);
            CrossSecureStorage.Current.SetValue("OwnUser", user.Id);
            DependencyManager.Me = user;

            new VoucherCode(user).SendVoucherCode();

            return true;
        }

        public Channel CreateChannel(User member, string channelName = null)
        {
            return CreateChannel(new List<User> { member }, channelName);
        }

        public Channel CreateChannel(List<User> members, string channelName = null)
        {
            var channelIdentifier = IdentifierCreator.UniqueDigits();
            var channel = new Channel(channelIdentifier, members, channelName);
            DependencyManager.ChannelsPage.ViewModel.Channels.Add(channel);
            DependencyManager.Database.InsertOrReplaceWithChildren(channel);

            var memberList = members.Aggregate("", (current, member) => current + member.Email + ";");
            memberList = memberList.Remove(memberList.Length - 1); // Remove last semicolon
            foreach (var member in members)
            {
                var preparedMessage = new Message(DependencyManager.Me.Id + ";" + channelIdentifier + ";" + memberList,
                    "onboarding")
                {
                    ChannelId = member.Id // Manipulated to call pull broadcast by receiver
                };

                new Task(() => { RestOperations.SendMessage(preparedMessage); }).Start(); // TODO: Handle in future if request is not succeeded
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
            return DependencyManager.Database.GetAllWithChildren<User>().Where(user => user.Id != DependencyManager.Me.Id).ToList();
        }

        public List<Channel> LoadChannels()
        {
            return DependencyManager.Database.GetAllWithChildren<Channel>();
        }

        public bool SendMessage(string message, Channel channel)
        {
            var preparedMessage = new EncryptionLogic(new Message(DependencyManager.Me.Id, message)).Encrypt();
            channel.View.ViewModel.Messages.Add(new DecryptionLogic(preparedMessage).Decrypt());
            channel.Messages.Add(preparedMessage);
            DependencyManager.Database.UpdateWithChildren(channel);

            // TODO: Handle REST return
            new Task(() => { RestOperations.SendMessage(preparedMessage); }).Start();
            return true;
            //return RestOperations.SendMessage(preparedMessage).Result;
        }

        public async void PullNewMessages()
        {
            while (true)
            {
                foreach (var channel in DependencyManager.ChannelsPage.ViewModel.Channels)
                {
                    foreach (var message in RestOperations.GetMessageBy(channel.Id).Result)
                    {
                        if (channel.Messages.Exists(item => item.Id == message.Id)) continue; // If message exists
                        channel.View.ViewModel.Messages.Add(new DecryptionLogic(message).Decrypt());
                        channel.Messages.Add(message);
                        DependencyManager.Database.UpdateWithChildren(channel);

                        Debug.WriteLine("=>=> " + channel.Members.Count + " :: " + message.ProcessingCounter);

                        if (message.ProcessingCounter + 1 >= channel.Members.Count)
                        {
                            // TODO: Handle REST return
                            new Task(() => { RestOperations.DeleteMessageBy(message.Id); }).Start();
                        }
                        else
                        {
                            // TODO: Handle REST return
                            new Task(() => { RestOperations.UpdateMessageProcessingCounterBy(message.Id); }).Start();
                        }
                    }
                }
                await Task.Delay(5000); // 5 seconds
            }
        }

        public async void PullChannelRequests()
        {
            while (true)
            {
                Debug.WriteLine("pull now to receiving channel " + DependencyManager.Me.Id);
                foreach (var message in RestOperations.GetMessageBy(DependencyManager.Me.Id).Result)
                {
                    Debug.WriteLine("pull msg " + message.Id);
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

                    var channel = new Channel(newChannelIdentifier, members);
                    channel.Messages.Add(new Message(sender, message.Text) { Timestamp = message.Timestamp });
                    DependencyManager.ChannelsPage.ViewModel.Channels.Add(channel);
                    DependencyManager.Database.InsertOrReplaceWithChildren(channel);

                    // TODO: Handle REST return
                    new Task(() => { RestOperations.DeleteMessageBy(message.Id); }).Start();
                }
                await Task.Delay(10000); // 10 seconds
            }
        }
    }
}
