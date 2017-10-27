namespace ModernEncryption.Interfaces
{
    internal interface IPullService
    {
        void PullNewMessages();
        void PullChannelRequests();
    }
}
