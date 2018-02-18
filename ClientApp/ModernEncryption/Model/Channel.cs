using System.Collections.Generic;
using ModernEncryption.Interfaces;
using ModernEncryption.Presentation.View;
using ModernEncryption.Translations;
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

        public bool ChannelKeyVisibility { get; set; } = true;

        public Channel()
        {
        }

        public Channel(string id, List<User> members, string name = null)
        {
            Id = id;
            Members = members;

            if (name == null)
            {
                if (members.Count > 1)
                    Name = members[0].Username + " " + AppResources.And + " " + (members.Count - 1) + " " + AppResources.MoreMembers;
                else
                    Name = members[0].Username;
            }
            else
                Name = name;
        }
    }
}
