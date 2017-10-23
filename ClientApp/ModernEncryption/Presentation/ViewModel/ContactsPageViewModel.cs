using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ContactsPageViewModel : INotifyPropertyChanged
    {
        private ContactsPage _view;
        private bool _multipleSelectionVisibility;
        private string _title = "Your contacts";
        public ObservableCollection<SelectableData<User>> Contacts { get; } = new ObservableCollection<SelectableData<User>>();
        public ICommand AddContactViaEmailCommand { protected set; get; }
        public ICommand TabbedContactCommand { protected set; get; }
        public ICommand ClickedCreateGroupCommand { protected set; get; }

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value) return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public bool MultipleSelectionVisibility
        {
            get => _multipleSelectionVisibility;
            private set
            {
                if (_multipleSelectionVisibility == value) return;
                _multipleSelectionVisibility = value;
                OnPropertyChanged("MultipleSelectionVisibility");
            }
        }

        public ContactsPageViewModel()
        {
            // Load all contact from local database
            foreach (var contact in DependencyManager.ChannelService.LoadContacts()) Contacts.Add(new SelectableData<User>(contact));

            AddContactViaEmailCommand = new Command<object>(param =>
            {
                var email = _view.FindByName<SearchBar>("email").Text;
                Contacts.Add(new SelectableData<User>(DependencyManager.ChannelService.AddUserBy(email)));
                _view.FindByName<SearchBar>("email").Text = "";
            });

            TabbedContactCommand = new Command<object>(param =>
            {
                var user = ((SelectableData<User>)param).Data;

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

            ClickedCreateGroupCommand = new Command<object>(param =>
            {
                var members = new List<User>();
                foreach (var contact in Contacts)
                {
                    if (!contact.Selected) continue;
                    members.Add(contact.Data);
                }

                // TODO: Check, if a channel exists with the same members

                if (members.Count > 0)
                    _view.Navigation.PushAsync(DependencyManager.ChannelService.CreateChannel(members).View);
            });
        }

        public void ActivateMultipleSelectionSupport()
        {
            MultipleSelectionVisibility = true; // Activate switches and create group button
        }

        public void SetView(ContactsPage view)
        {
            _view = view;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
