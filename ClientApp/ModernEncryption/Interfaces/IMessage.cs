namespace ModernEncryption.Interfaces
{
    internal interface IMessage
    {
        string Text { get; }
        string Sender { get; }
        int Timestamp { get; }
    }
}
