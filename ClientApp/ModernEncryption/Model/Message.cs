using ModernEncryption.Interfaces;
using Newtonsoft.Json;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    [Table("Message")]
    public class Message : IEntity
    {
        [PrimaryKey, AutoIncrement, JsonIgnore]
        public int Id { get; set; }

        [ForeignKey(typeof(Channel)), JsonProperty(PropertyName = "receivingChannel")]
        public int ChannelId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All), JsonIgnore]
        public Channel Channel { get; set; }

        [JsonProperty(PropertyName = "messageHeader")]
        public string MessageHeader { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Text { get; set; }

        public Message()
        {
        }

        public Message(string messageHeader, string message)
        {
            MessageHeader = messageHeader;
            // TODO: Generate timestamp and NOW() and initialize Timestamp-property with it
            Text = message;
        }
    }
}
