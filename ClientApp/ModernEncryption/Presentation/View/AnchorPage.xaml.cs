using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnchorPage : TabbedPage
    {
        public AnchorPage()
        {
            InitializeComponent();

            var channelsPage = new NavigationPage(DependencyManager.ChannelsPage)
            {
                Icon = "chat.png",
                Title = "Channels"
            };

            var contactsPage = new NavigationPage(DependencyManager.ContactsPage)
            {
                Icon = "contact.png",
                Title = "Contacts"
            };

            Children.Add(channelsPage);
            Children.Add(contactsPage);
        }
    }
}