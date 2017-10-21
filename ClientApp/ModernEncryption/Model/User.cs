using System.Collections.Generic;
using ModernEncryption.Interfaces;
using Newtonsoft.Json;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    [Table("User")]
    public class User : IEntity
    {
        [PrimaryKey, JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [ManyToMany(typeof(ChannelUser), CascadeOperations = CascadeOperation.All), JsonIgnore]
        public List<Channel> Channels { get; set; }

        [MaxLength(18), JsonProperty(PropertyName = "firstname")]
        public string Firstname { get; set; }

        [MaxLength(18), JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }

        [Unique, MaxLength(32), JsonProperty(PropertyName = "eMail")]
        public string Email { get; set; }

        public User()
        {
        }

        public User(string firstname, string surname, string email)
        {
            Firstname = firstname;
            Surname = surname;
            Email = email;
        }
    }
}
