using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Translations;
using ModernEncryption.Utils;
using SQLiteNetExtensions.Extensions;

namespace ModernEncryption.Service
{
    internal class ChannelService : IChannelService
    {
        private IRestService RestService { get; }

        public IKeyHandling GenerateKeys;

        public ChannelService()
        {
            RestService = new RestService();
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
                    AppResources.CryptedOnBoardingMessage)
                {
                    ChannelId = member.Id // Manipulated to call pull broadcast by receiver
                };

                new Task(() => { RestService.SendMessage(preparedMessage); }).Start(); // TODO: Handle in future if request is not succeeded
            }

            return channel;
        }

        public List<Channel> LoadChannels()
        {
            return DependencyManager.Database.GetAllWithChildren<Channel>();
        }

        public List<DecryptedMessage> LoadDecryptedMessagesForChannel(Channel channel)
        {
            return channel.Messages.Select(encryptedMessage => new DecryptionLogic(encryptedMessage, channel.KeyTable)).Select(decryption => ((IDecrypt)decryption).Decrypt()).ToList();
        }

        public bool SendMessage(string message, Channel channel)
        {
            IEncrypt encryption = new EncryptionLogic(new Message(DependencyManager.Me.Id, message), channel.KeyTable);
            var preparedMessage = encryption.Encrypt();
            IDecrypt decryption = new DecryptionLogic(preparedMessage, channel.KeyTable);
            channel.View.ViewModel.Messages.Add(decryption.Decrypt());
            channel.Messages.Add(preparedMessage);
            DependencyManager.Database.InsertWithChildren(preparedMessage);
            DependencyManager.Database.UpdateWithChildren(channel);

            // TODO: Handle REST return
            new Task(() => { RestService.SendMessage(preparedMessage); }).Start();
            return true;
            //return RestService.SendMessage(preparedMessage).Result;
        }
    }
}
