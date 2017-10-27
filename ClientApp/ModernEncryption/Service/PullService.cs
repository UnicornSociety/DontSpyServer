using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Rest;
using SQLiteNetExtensions.Extensions;

namespace ModernEncryption.Service
{
    internal class PullService : IPullService
    {
        private RestOperations RestOperations { get; }

        public PullService()
        {
            RestOperations = new RestOperations();
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
                        var member = DependencyManager.UserService.AddUserBy(receivingChannelSplit[i]);
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
