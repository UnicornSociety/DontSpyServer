using System.Collections.Generic;
using ModernEncryption.Interfaces;
using ModernEncryption.Utils;
using Newtonsoft.Json;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    [Table("User")]
    public class User : IEntity
    {
        [PrimaryKey, Unique, Column("id"), MaxLength(40), JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [ManyToMany(typeof(ChannelUser), CascadeOperations = CascadeOperation.All), JsonIgnore]
        public List<Channel> Channels { get; set; }

        [Column("firstname"), MaxLength(30), JsonProperty(PropertyName = "firstname")]
        public string Firstname { get; set; }

        [Column("surname"), MaxLength(30), JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }

        [Unique, Column("email"), MaxLength(254), JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        public User()
        {
        }

        public User(string firstname, string surname, string email)
        {
            Id = IdentifierCreator.UniqueDigits();
            Firstname = firstname;
            Surname = surname;
            Email = email;
        }
    }
}
