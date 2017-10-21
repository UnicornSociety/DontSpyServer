using System.Collections.Generic;
using ModernEncryption.Interfaces;
using ModernEncryption.Presentation.View;
using Newtonsoft.Json;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    [Table("Channel")]
    public class Channel : IEntity
    {
        [PrimaryKey]
        public int Id { get; set; }

        [ManyToMany(typeof(ChannelUser), CascadeOperations = CascadeOperation.All)]
        public List<User> Members { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Message> Messages { get; set; }

        public string Name { get; set; }

        [Ignore]
        public ChannelPage View { get; set; }

        public Channel()
        {
        }

        public Channel(int id, List<User> members, Message message, string name = null)
        {
            Id = id;
            Members = members;
            Messages = new List<Message> { message };

            if (name == null) Name = members[0].Firstname + " and " + members.Count + " more members";
            else Name = name;

            View = new ChannelPage(); // TODO: Should called by DB.Get, too
            View.ViewModel.Channels.Add(this);
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
    }
}
