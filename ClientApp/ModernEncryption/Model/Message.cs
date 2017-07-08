namespace ModernEncryption.Model
{
    internal class Message
    {
        public int Sender { get; }
        public int KeyNumber { get; }
        public int Timestamp { get; }
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
