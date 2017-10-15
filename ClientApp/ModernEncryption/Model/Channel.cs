using System.Collections.Generic;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Interfaces;
using ModernEncryption.Presentation.View;
using Plugin.SecureStorage;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using Xamarin.Forms;

namespace ModernEncryption.Model
{
    [Table("Channel")]
    public class Channel : IEntity
    {
        private Dictionary<int, int> _keyTable;

        [PrimaryKey]
        public int Id { get; set; }

        [ManyToMany(typeof(UserChannel))]
        public List<User> Members { get; set; }

        [OneToMany]
        public List<Message> Messages { get; set; }

        public GroupIndicator ChannelType { get; set; }

        private int _keyReference = -1;

        public int KeyReference
        {
            get { return _keyReference; }
            set
            {
                ChannelPage = new ChatPage(this);
            }
        }

        [Ignore]
        public Page ChannelPage { get; private set; } = new ChatPage(new Channel(2, new List<User>(), GroupIndicator.Single)); //new Channel(Id, Members, ChannelType) TODO: Instead of null, set a new Page of the page in which user enter the key

        [Ignore]
        public Dictionary<int, int> KeyTable
        {
            get
            {
                if (KeyReference.Equals(-1)) return null;
                if (_keyTable != null) return _keyTable;

                var keyTableGenerator = new GenerateKeys();
                _keyTable = keyTableGenerator.KeyTable(1600, CrossSecureStorage.Current.GetValue(KeyReference.ToString()));
                return _keyTable;
            }
        }

        public enum GroupIndicator
        {
            Single, Group
        }

        public Channel()
        {
        }

        public Channel(int id, List<User> members, GroupIndicator channelType)
        {
            Id = id;
            Members = members;
            ChannelType = channelType;
        }
    }
}
