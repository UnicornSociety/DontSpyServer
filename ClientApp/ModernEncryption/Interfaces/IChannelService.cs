using System.Collections.Generic;
using ModernEncryption.Model;

namespace ModernEncryption.Interfaces
{
    internal interface IChannelService
    {
        Channel CreateChannel(User member, string channelName = null);
        Channel CreateChannel(List<User> members, string channelName = null);
        List<Channel> LoadChannels();
        List<DecryptedMessage> LoadDecryptedMessagesForChannel(Channel channel);
        bool SendMessage(string message, Channel channel);
    }
}
