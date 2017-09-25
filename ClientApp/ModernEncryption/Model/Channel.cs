using System.Collections.Generic;
using ModernEncryption.Interfaces;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    [Table("Channel")]
    public class Channel : IEntity
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string test { get; set; }

        [ManyToMany(typeof(UserChannel))]
        public List<User> Members { get; set; }

        public Channel()
        {
        }

        public Channel(int id, List<User> members)
        {
            Id = id;
            Members = members;
        } 
    }
}
