using System.Collections.Generic;
using System.Threading.Tasks;
using ModernEncryption.Model;

namespace ModernEncryption.Interfaces
{
    internal interface IChannelService
    {
        bool CreateOwnUser(User user);
        Channel CreateChannel(User member, string channelName = null);
        Channel CreateChannel(List<User> members, string channelName = null);
        User AddUserBy(string email);
        List<User> LoadContacts();
        List<Channel> LoadChannels();
        bool SendMessage(string message, Channel channel);
        void PullNewMessages();
        void PullChannelRequests();
    }
}
