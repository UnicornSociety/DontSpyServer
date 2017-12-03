using System;
using System.Collections.Generic;
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

        [PrimaryKey, Unique, Column("id"), MaxLength(40)]
        public string Id { get; set; }

        [ManyToMany(typeof(ChannelUser), CascadeOperations = CascadeOperation.All)]
        public List<User> Members { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Message> Messages { get; set; } = new List<Message>();

        public string Name { get; set; }

        [Ignore]
        public ChannelPage View => _channelView ?? (_channelView = new ChannelPage(this));

        public Dictionary<int, int> _keyTable;

        public Dictionary<int, int> KeyTable
        { 
            get
            {
                if (_keyTable != null) return _keyTable;
                IGenerateKey generateKey = new GenerateKeys();
                var key = CrossSecureStorage.Current.GetValue(Id);
                _keyTable = generateKey.KeyTable(key);
                return _keyTable;
            }
        }


        public Channel()
        {
        }

        public Channel(string id, List<User> members, string name = null)
        {
            IGenerateKey generateKey = new GenerateKeys();
            var key = generateKey.ProduceKeys(1600);
            CrossSecureStorage.Current.SetValue(id, key);
            Id = id;
            Members = members;
            

            if (name == null)
            {
                if (members.Count > 1)
                    Name = members[0].Firstname + " " + AppResources.And + " " + (members.Count - 1) + " " + AppResources.MoreMembers;
                else
                    Name = members[0].Firstname + " " + members[0].Surname;
            }
            else
                Name = name;
        }
    }
}
