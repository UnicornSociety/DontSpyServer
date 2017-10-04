using ModernEncryption.Interfaces;
using Newtonsoft.Json;

namespace ModernEncryption.Model
{
    internal class EncryptedMessage : Message, IMessage
    {
        [JsonProperty(PropertyName = "message")]
        public string Text { get; }

        [JsonConstructor]
        public EncryptedMessage(string text, string sender, int timestamp) : base(sender, timestamp)
        {
            Text = text;
        }

        public EncryptedMessage(string text, DecryptedMessage decryptedMessage) : base(decryptedMessage.Sender, decryptedMessage.Timestamp)
        {
            Text = text;
        }
    }
}
