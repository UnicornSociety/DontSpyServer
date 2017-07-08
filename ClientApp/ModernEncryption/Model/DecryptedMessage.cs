using ModernEncryption.Interfaces;

namespace ModernEncryption.Model
{
    internal class DecryptedMessage : Message, IMessage
    {
        public string Text { get; }

        public DecryptedMessage(string text, int sender, int keyNumber, int timestamp, int receiver) : base(sender, keyNumber, timestamp, receiver)
        {
            Text = text;
        }

        public DecryptedMessage(string text, EncryptedMessage encryptedMessage) : base(encryptedMessage.Sender, encryptedMessage.KeyNumber, encryptedMessage.Timestamp, encryptedMessage.Receiver)
        {
            Text = text;
        }
    }
}
