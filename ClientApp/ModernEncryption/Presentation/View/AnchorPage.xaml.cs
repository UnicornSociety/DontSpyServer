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
                Title = "Channels",
                BarBackgroundColor = Color.CornflowerBlue,
                BarTextColor = Color.Black
            };

            var contactsPage = new NavigationPage(DependencyManager.ContactsPage)
            {
                Icon = "contact.png",
                Title = "Contacts",
                BarBackgroundColor = Color.CornflowerBlue,
                BarTextColor = Color.Black
            };

            BarBackgroundColor = Color.White;
            BarTextColor = Color.Blue;

            NavigationPage.SetHasNavigationBar(channelsPage, true);
            NavigationPage.SetHasNavigationBar(contactsPage, true);

            Children.Add(channelsPage);
            Children.Add(contactsPage);
        }
    }
}