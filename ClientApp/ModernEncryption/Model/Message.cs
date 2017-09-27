using Newtonsoft.Json;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    public class Message
    {
        [JsonProperty(PropertyName = "sender")]
        public int Sender { get; }
        [JsonProperty(PropertyName = "keyNumber")]
        public int KeyNumber { get; }
        [JsonProperty(PropertyName = "timestamp")]
        public int Timestamp { get; }
        [JsonProperty(PropertyName = "receiver")]
        public int Receiver { get; }
        [ForeignKey(typeof(Channel)), JsonIgnore]
        public int ChannelId{get; set; }

        public Message(int sender, int keyNumber, int timestamp, int receiver)
        {
            Sender = sender;
            KeyNumber = keyNumber;
            Timestamp = timestamp;
            Receiver = receiver;
        }
    }
}
