using System.Collections.Generic;
using System.Threading.Tasks;
using ModernEncryption.Model;
using SQLiteNetExtensions.Extensions;

namespace ModernEncryption.Service
{
    internal class NewRequestorService
    {
        private MessageService _messageService;
        private UserService _userService;

        public void Execute(int myUserId, int checkForNewChannelRequestsInterval, int checkForNewMessagesInterval)
        {
            _messageService = new MessageService();
            _userService = new UserService();
            checkForNewChannelRequests(myUserId, checkForNewChannelRequestsInterval);
            checkForNewMessages(checkForNewMessagesInterval);
        }

        private async void checkForNewChannelRequests(int userId, int checkForNewChannelRequestsInterval)
        {
            foreach (var message in _messageService.GetMessage(userId).Result)
            {
                var senderField = message.Sender.Split(';'); // SenderId, ChannelId, MemberA, .., MemberN
                var sender = senderField[0];
                var members = new List<User>();
                for (var i = 2; i < senderField.Length; i++)
                {
                    var user = _userService.GetUser(senderField[i]).Result;
                    members.Add(user);
                    // TODO: Save user in LocalDatabase, if not exists
                    // TODO: Add user to ObservableCollection in Contacts
                }

                var channel = new Channel(int.Parse(senderField[1]), members, Channel.GroupIndicator.Single);
                channel.Messages = new List<Message>{ message };



                var channel = new Channel(channelId, new List<User> { user }, groupIndicator);
                channel.Messages.Add(message);
                App.Database.InsertWithChildren(channel);
                /* TODO var app = new App(true);
                app.AllChannels[app.AllChannels.Length + 1] = channel;*/
            }

            await Task.Delay(checkForNewChannelRequestsInterval);
        }

        private async void checkForNewMessages(int checkForNewMessagesInterval)
        {
            // TODO
            await Task.Delay(checkForNewMessagesInterval);
        }
    }
}
