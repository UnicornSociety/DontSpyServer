using ModernEncryption.Interfaces;
using Newtonsoft.Json;

namespace ModernEncryption.Model
{
    internal class DecryptedMessage : Message, IMessage
    {
        [JsonProperty(PropertyName = "message")]
        public string Text { get; }

        public DecryptedMessage(string text, string sender, int timestamp) : base(sender, timestamp)
        {
            Text = text;
        }

        public DecryptedMessage(string text, EncryptedMessage encryptedMessage) : base(encryptedMessage.Sender, encryptedMessage.Timestamp)
        {
            Text = text;
        }
    }
}
