using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Interfaces;
using ModernEncryption.Presentation.View;
using ModernEncryption.Translations;
using Plugin.SecureStorage;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    [Table("Channel")]
    public class Channel : IEntity
    {
        private ChannelPage _channelView;

        private readonly IKeyHandling _keyHandler = new KeyHandling();

        [PrimaryKey, Unique, Column("id"), MaxLength(40)]
        public string Id { get; set; }

        [ManyToMany(typeof(ChannelUser), CascadeOperations = CascadeOperation.All)]
        public List<User> Members { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Message> Messages { get; set; } = new List<Message>();

        public string Name { get; set; }

        [Ignore]
        public ChannelPage View => _channelView ?? (_channelView = new ChannelPage(this));

        private Dictionary<int, int> _keyTable;

        [Ignore]
        public Dictionary<int, int> KeyTable
        { 
            get
            {
                if (_keyTable != null) return _keyTable;
                var key = CrossSecureStorage.Current.GetValue(Id);
                int[] _key = key.Split(';').Select(n => Convert.ToInt32(n)).ToArray();
                _keyTable = _keyHandler.KeyTable(_key);
                return _keyTable;
            }
        }


        public Channel()
        {
        }

        public Channel(string id, List<User> members, string name = null)
        {
            var key = _keyHandler.ProduceKeys(8100);
            Debug.WriteLine(key);
            CrossSecureStorage.Current.SetValue(id, key.ToString());
            Id = id;
            Members = members;
            

            if (name == null)
            {
                if (members.Count > 1)
                    Name = members[0].Displayname + " " + AppResources.And + " " + (members.Count - 1) + " " + AppResources.MoreMembers;
                else
                    Name = members[0].Displayname;
            }
            else
                Name = name;
        }
    }
}
