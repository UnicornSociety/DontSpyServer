using Newtonsoft.Json;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    public class Message
    {
        [JsonProperty(PropertyName = "sender")]
        public string Sender { get; }
        [JsonProperty(PropertyName = "timestamp")]
        public int Timestamp { get; }
        [ForeignKey(typeof(Channel)), JsonProperty(PropertyName = "channel")]
        public int Channel{get; set; }

        public Message(string sender, int timestamp)
        {
            Sender = sender;
            Timestamp = timestamp;
        }
    }
}
