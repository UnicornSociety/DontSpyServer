using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.Validation;
using ModernEncryption.Presentation.Validation.Rules;
using ModernEncryption.Presentation.View;
using ModernEncryption.Translations;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ContactsPageViewModel : ValidationBase, INotifyPropertyChanged
    {
        private ContactsPage _view;
        private bool _multipleSelectionVisibility;
        private string _title = AppResources.ContactsHeading;
        private ValidatableObject<string> _username = new ValidatableObject<string>();
        public ObservableCollection<SelectableData<User>> Contacts { get; } = new ObservableCollection<SelectableData<User>>();
        public ICommand AddContactViaUsernameCommand { protected set; get; }
        public ICommand TabbedContactCommand { protected set; get; }
        public ICommand ClickedCreateGroupCommand { protected set; get; }
        public ICommand ValidateusernameCommand { protected set; get; }

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

        public ValidatableObject<string> Username
        {
            get => _username;
            set
            {
                if (_username == value) return;
                _username = value;
                OnPropertyChanged("Username");
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
            AddValidations();

            // Load all contact from local database
            foreach (var contact in DependencyManager.UserService.LoadContacts()) Contacts.Add(new SelectableData<User>(contact));

            AddContactViaUsernameCommand = new Command<object>(param =>
            {
                if (!Validate()) return;

                if (DependencyManager.Me.Username.Equals(Username.Value)) return; // Prevent to add the own user
                var user = DependencyManager.UserService.AddUserBy(Username.Value);
                if (user != null) Contacts.Add(new SelectableData<User>(user));
                Username.Value = "";
            });

            TabbedContactCommand = new Command<object>(param =>
            {
                var user = ((SelectableData<User>)param).Data;

                // Check if a single channel with the tabbed user is existing
                ChannelPage channelPage = null;
                foreach (var channel in DependencyManager.ChannelsPage.ViewModel.Channels)
                {
                    if (!channel.Members.Contains(user)) continue;
                    if (channel.Members.Count > 1) continue;
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

                if (members.Count <= 0) return;

                // Check if a group channel with the selected user is existing
                ChannelPage channelPage = null;
                foreach (var channel in DependencyManager.ChannelsPage.ViewModel.Channels)
                {
                    if (channel.Members.Count != members.Count || channel.Members.Except(members).Any()) continue;
                    // Is existing
                    channelPage = channel.View;
                }

                if (channelPage == null) channelPage = DependencyManager.ChannelService.CreateChannel(members).View;
                _view.Navigation.PushAsync(channelPage);
            });

            ValidateusernameCommand = new Command<object>(param =>
            {
                Validate();
            });
        }

        public void ActivateMultipleSelectionSupport()
        {
            MultipleSelectionVisibility = true; // Activate switches and create group button
        }

        public void DeactivateMultipleSelectionSupport()
        {
            MultipleSelectionVisibility = false; // Deactivate switches and create group button
        }

        protected sealed override void AddValidations()
        {
            _username.Validations.Add(new EmailRule<string>());
        }

        protected override bool Validate()
        {
            return _username.Validate();
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
