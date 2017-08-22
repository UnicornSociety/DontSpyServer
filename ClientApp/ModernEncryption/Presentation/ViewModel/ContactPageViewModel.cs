using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using ModernEncryption.Service;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ContactPageViewModel : INotifyPropertyChanged
    {
        private ContactPage _view;

        public string Title { get; set; } = "ContactPage";
        public ObservableCollection<User> Contacts { get; }
        public ICommand AddContactViaEmailCommand { protected set; get; }

        public ContactPageViewModel()
        {
            Contacts = new ObservableCollection<User>();
            LoadContacts();

            AddContactViaEmailCommand = new Command<object>(param =>
            {
                var email = _view.FindByName<SearchBar>("email").Text;

                IUserService userService = new UserService();
                var user = userService.GetUser(email).Result;

                if (user == null) return;
                SaveContact(user);
            });
        }

        public void SetView(ContactPage view)
        {
            _view = view;
        }

        private void LoadContacts()
        {
            var contacts = DependencyHandler.Db().Get<User>("SELECT * FROM user");
            foreach (var contact in contacts)
            {
                Contacts.Add(contact);
            }
        }

        private void SaveContact(User user)
        {
            var userByEmail = DependencyHandler.Db().Get<User>("SELECT * FROM user WHERE email='" + user.Email + "'");
            if (userByEmail.Count > 0) return;

            DependencyHandler.Db().Save(user);
            Contacts.Add(user); // Add user to current visible view
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
