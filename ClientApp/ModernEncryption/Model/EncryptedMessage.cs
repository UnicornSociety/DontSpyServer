using ModernEncryption.Interfaces;

namespace ModernEncryption.Model
{
    internal class EncryptedMessage : Message, IMessage
    {
        public string Text { get; }

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
