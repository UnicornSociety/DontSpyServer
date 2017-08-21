using System.Collections.ObjectModel;
using System.ComponentModel;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ContactPageViewModel:INotifyPropertyChanged
    {
        public string Title { get; set; } = "ContactPage";
        public ObservableCollection<User> Contacts { get; }

        public ContactPageViewModel()
        {
            Contacts = new ObservableCollection<User>();

            Contacts.Add(new User("Lukas", "Ruf", "lukas.ruf@sfzlab.de"));
            Contacts.Add(new User("Mai", "Saito", "mai.saito@sfzlab.de"));
            Contacts.Add(new User("Max", "Mustermann", "max@mustermann.de"));
            Contacts.Add(new User("Tobias", "Straub", "tobias.straub@sfzlab.de"));
            Contacts.Add(new User("Helmut", "Ruf", "helmut.ruf@sfzlab.de"));

            // Simulation of persist data
            //var primaryKey = DependencyHandler.Db().Save(new User("Tobias", "Straub", "abc@def.de"));
            //Debug.WriteLine(DependencyHandler.Db().Get<User>(primaryKey).Email);
        }

        public void SetView(ContactPage view)
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
