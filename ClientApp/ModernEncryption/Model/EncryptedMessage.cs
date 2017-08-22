using ModernEncryption.Interfaces;
using Newtonsoft.Json;

namespace ModernEncryption.Model
{
    internal class EncryptedMessage : Message, IMessage
    {
        [JsonProperty(PropertyName = "message")]
        public string Text { get; }

        [JsonConstructor]
        public EncryptedMessage(string text, int sender, int keyNumber, int timestamp, int receiver) : base(sender, keyNumber, timestamp, receiver)
        {
            Text = text;
        }

        public EncryptedMessage(string text, DecryptedMessage decryptedMessage) : base(decryptedMessage.Sender, decryptedMessage.KeyNumber, decryptedMessage.Timestamp, decryptedMessage.Receiver)
        {
            Text = text;
        }
    }
}
