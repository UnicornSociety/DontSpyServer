using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using ModernEncryption.BusinessLogic.Crypto;
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
    public class NewGroupPageViewModel : INotifyPropertyChanged
    {
        private NewGroupPage _view;

        public string Title { get; set; } = "Contacts";
        public ObservableCollection<User> Contacts { get; }
        public ICommand AddContactViaEmailCommand { protected set; get; }
        public ICommand TabbedContactCommand { protected set; get; }

        public NewGroupPageViewModel()
        {
            Contacts = new ObservableCollection<User>();
            Contacts.Add(new User("Max", "Muster", "emailmax"));

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
                var user = (User)param;

                // DEBUGGING: Creating a channel
                /*var channel = new Channel(43, new List<User> { user }, Channel.GroupIndicator.Single);
                Database.InsertWithChildren(channel);

                var xy1 = Database.GetWithChildren<User>(user.Id);
                var xy2 = Database.GetWithChildren<Channel>(channel.Id);
                // var result = Database.GetAllWithChildren<Channel>(x => x.Members.Contains(user));
                // DEBUGGING END*/

                var Result = App.Database.GetAllWithChildren<Channel>(c => c.Members.Contains(user) && c.ChannelType == Channel.GroupIndicator.Single); //muss noch so machen das Grupppen wo auch der user drin ist nicht gezählt werden

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
                    var channel = new Channel(user.Id + channelIdPart, new List<User> { user },
                        Channel.GroupIndicator.Single)
                    {
                        KeyReference = new GenerateKeys().CreateKey()
                    };
                    App.Database.InsertWithChildren(channel);
                    _view.Navigation.PushAsync(channel.ChannelPage);
                }
            });
        }

        public void SetView(NewGroupPage view)
        {
            _view = view;
        }

        private void LoadContacts()
        {
            var contacts = App.Database.Query<User>("SELECT * FROM user");
            foreach (var contact in contacts)
            {
                Contacts.Add(contact);
            }
        }

        private void SaveContact(User user)
        {
            var userByEmail = App.Database.Query<User>("SELECT * FROM user WHERE email='?'", user.Email);
            if (userByEmail.Count > 0) return;

            App.Database.Insert(user);
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

