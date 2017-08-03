namespace ModernEncryption.Presentation.ViewModel
{
    internal class ChatOverviewPageViewModel 
    {
        public string Title { get; set; } = "ChatOverviewPage";

        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int Timestamp { get; set; }
       
        public ChatOverviewPageViewModel()
        {
            Surname = "Mustermann";
            Firstname = "Max";
            Sender = 1;
            Receiver = 2;
            Timestamp = 123456;
        }

    }
}
