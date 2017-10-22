namespace ModernEncryption.Model
{
    public class DecryptedMessage
    {
        public string Id { get; set; }
        public int Timestamp { get; }
        public string Text { get; }

        public DecryptedMessage(string id, int timestamp, string text)
        {
            Id = id;
            Timestamp = timestamp;
            Text = text;
        }
    }
}
