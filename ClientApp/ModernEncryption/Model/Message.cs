using Newtonsoft.Json;

namespace ModernEncryption.Model
{
    internal class Message
    {
        [JsonProperty(PropertyName = "sender")]
        public int Sender { get; }
        [JsonProperty(PropertyName = "keyNumber")]
        public int KeyNumber { get; }
        [JsonProperty(PropertyName = "timestamp")]
        public int Timestamp { get; }
        [JsonProperty(PropertyName = "receiver")]
        public int Receiver { get; }

        public Message(int sender, int keyNumber, int timestamp, int receiver)
        {
            Sender = sender;
            KeyNumber = keyNumber;
            Timestamp = timestamp;
            Receiver = receiver;
        }
    }
}
