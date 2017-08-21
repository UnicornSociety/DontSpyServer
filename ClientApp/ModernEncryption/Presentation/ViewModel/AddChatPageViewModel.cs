using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    class AddChatPageViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; } = "AddChatPage";

        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int Timestamp { get; set; }


        public ICommand BackToChatOverViewCommand { protected set; get; }

        public ObservableCollection<User> Contacts { get; }

public AddChatPageViewModel()
{
            this.BackToChatOverViewCommand = new Command<string>((key) =>
             {
                Debug.WriteLine("Hallo Helmut");
                        });

            Contacts = new ObservableCollection<User>();

            Contacts.Add(new User("Lukas", "Ruf", "lukas.ruf@sfzlab.de"));
            Contacts.Add(new User("Mai", "Saito", "mai.saito@sfzlab.de"));
            Contacts.Add(new User("Max", "Mustermann", "max@mustermann.de"));
            Contacts.Add(new User("Tobias", "Straub", "tobias.straub@sfzlab.de"));
            Contacts.Add(new User("Helmut", "Ruf", "helmut.ruf@sfzlab.de")); Surname = "Mustermann";
        }

        /*TODO: Ajust getter & Setter for propertychanged*/

        public void SetView(AddChatPage view)
        {
            _view = view;
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
