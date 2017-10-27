using ModernEncryption.Interfaces;
using ModernEncryption.Utils;
using Newtonsoft.Json;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    [Table("Message")]
    public class Message : IEntity
    {
        [PrimaryKey, JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [ForeignKey(typeof(Channel)), JsonProperty(PropertyName = "receivingChannel")]
        public string ChannelId { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All), JsonIgnore]
        public Channel Channel { get; set; }

        [JsonProperty(PropertyName = "messageHeader")]
        public string MessageHeader { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "processingCounter")]
        public int ProcessingCounter { get; set; }

        public Message()
        {
        }

        public Message(string messageHeader, string message)
        {
            Id = IdentifierCreator.UniqueDigits();
            MessageHeader = messageHeader;
            Timestamp = TimeManagement.UnixTimestampNow;
            Text = message;
            ProcessingCounter = 0;
        }
    }
}
