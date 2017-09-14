using System;
using System.Collections.Generic;
using System.Text;
using ModernEncryption.Interfaces;
using Newtonsoft.Json;
using SQLite;

namespace ModernEncryption.Model
{
    public class Channel : IEntity
    {
        [PrimaryKey, Column("id")]
        public int Id { get; set; }

        [Column("members")]
        public LinkedList<User> Members { get; set; }

        public Channel()
        {
            
        }

        public Channel(int id, LinkedList<User> members)
        {
            Id = id;
            Members = members;
        }
    }
}
