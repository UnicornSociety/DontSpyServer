using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Rest;
using ModernEncryption.Utils;
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
    }
}
