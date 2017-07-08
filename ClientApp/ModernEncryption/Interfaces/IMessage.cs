namespace ModernEncryption.Interfaces
{
    internal interface IMessage
    {
        string Text { get; }
        int Sender { get; }
        int KeyNumber { get; }
        int Timestamp { get; }
        int Receiver { get; }
    }
}
