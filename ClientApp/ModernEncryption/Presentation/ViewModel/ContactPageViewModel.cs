using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using ModernEncryption.Service;
using Org.BouncyCastle.Utilities;
using Plugin.SecureStorage;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ContactPageViewModel : INotifyPropertyChanged
    {
        private ContactPage _view;
        private SQLiteConnection Database { get; } = DependencyService.Get<IStorage>().GetConnection();

        public string Title { get; set; } = "Kontakte";
        public ObservableCollection<User> Contacts { get; }
        public ICommand AddContactViaEmailCommand { protected set; get; }
        public ICommand TabbedContactCommand { protected set; get; }

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

            TabbedContactCommand = new Command<object>(param =>
            {
                var user = (User) param;

                // DEBUGGING: Creating a channel
                /*var channel = new Channel(43, new List<User> { user }, Channel.GroupIndicator.Single);
                Database.InsertWithChildren(channel);

                var xy1 = Database.GetWithChildren<User>(user.Id);
                var xy2 = Database.GetWithChildren<Channel>(channel.Id);
                // var result = Database.GetAllWithChildren<Channel>(x => x.Members.Contains(user));
                // DEBUGGING END*/

                var Result = Database.GetAllWithChildren<Channel>(c => c.Members.Contains(user) && c.ChannelType == Channel.GroupIndicator.Single); //muss noch so machen das Grupppen wo auch der user drin ist nicht gezählt werden

                int channelIdPart = 1;
                if (CrossSecureStorage.Current.HasKey("channelID"))
                {
                    var channelId = CrossSecureStorage.Current.GetValue("channelID");
                    channelIdPart = int.Parse(channelId);
                    channelIdPart++;
                    CrossSecureStorage.Current.SetValue(channelId, channelIdPart.ToString());
                }
                else
                {
                    CrossSecureStorage.Current.SetValue("channelID", "1");
                }


                if (Result.Count > 0)
                {
                    _view.Navigation.PushAsync(new ChatPage(Result[0]));//channel casten
                }
                else
                {
                    var channel = new Channel(user.Id+channelIdPart,new List<User>{ user}, Channel.GroupIndicator.Single);
                    Database.InsertWithChildren(channel);
                    _view.Navigation.PushAsync(new ChatPage(channel));
                }
            });
        }

        public void SetView(ContactPage view)
        {
            _view = view;
        }

        private void LoadContacts()
        {
            var contacts = Database.Query<User>("SELECT * FROM user");
            foreach (var contact in contacts)
            {
                Contacts.Add(contact);
            }
        }

        private void SaveContact(User user)
        {
            var userByEmail = Database.Query<User>("SELECT * FROM user WHERE email='?'", user.Email);
            if (userByEmail.Count > 0) return;

            Database.Insert(user);
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
