using System.Collections.ObjectModel;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ContactsPageViewModel
    {
        private ContactsPage _view;
        public ObservableCollection<User> Contacts { get; } = new ObservableCollection<User>();
        public ICommand TabbedContactCommand { protected set; get; }
        public ICommand AddContactViaEmailCommand { protected set; get; }

        public ContactsPageViewModel()
        {
            // Load all contact from local database
            foreach (var contact in DependencyManager.ChannelService.LoadContacts()) Contacts.Add(contact);

            TabbedContactCommand = new Command<object>(param =>
            {
                var user = (User)param;

                // Check if a single channel with the tabbed user is existing
                ChannelPage channelPage = null;
                foreach (var channel in DependencyManager.ChannelsPage.ViewModel.Channels)
                {
                    if (!channel.Members.Contains(user)) return;
                    if (channel.Members.Count > 1) return;
                    // Is existing
                    channelPage = channel.View;
                }
                if (channelPage == null) channelPage = DependencyManager.ChannelService.CreateChannel(user).View;

                _view.Navigation.PushAsync(channelPage);
            });

            AddContactViaEmailCommand = new Command<object>(param =>
            {
                var email = _view.FindByName<SearchBar>("email").Text;
                Contacts.Add(DependencyManager.ChannelService.AddUserBy(email));
            });
        }

        public void SetView(ContactsPage view)
        {
            _view = view;
        }
    }
}
