namespace ModernEncryption.Model
{
    public class DecryptedMessage
    {
        public string Id { get; set; }
        public int Timestamp { get; }
        public string Text { get; }
        public User Sender { get; } = new User("Unknown");

        public DecryptedMessage(string id, int timestamp, string text, string sender)
        {
            Id = id;
            Timestamp = timestamp;
            Text = text;

            if (DependencyManager.Me.Id.Equals(sender))
            {
                Sender = DependencyManager.Me;
            }
            else
            {
                foreach (var contact in DependencyManager.ContactsPage.ViewModel.Contacts)
                {
                    if (contact.Data.Id.Equals(sender))
                        Sender = contact.Data;
                }
            }
        }
    }
}
