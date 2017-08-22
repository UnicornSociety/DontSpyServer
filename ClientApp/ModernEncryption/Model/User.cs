using System.ComponentModel;
using ModernEncryption.Interfaces;
using Newtonsoft.Json;
using SQLite;

namespace ModernEncryption.Model
{
    public class User : IEntity, INotifyPropertyChanged
    {
        private int _id;
        private string _firstname;
        private string _surname;
        private string _email;

        [PrimaryKey, AutoIncrement, Column("id")]
        [JsonIgnore]
        public int Id
        {
            set
            {
                if (_id == value) return;
                _id = value;
                OnPropertyChanged("Id");
            }
            get => _id;
        }

        [MaxLength(18), Column("firstname")]
        [JsonProperty(PropertyName = "firstname")]
        public string Firstname
        {
            set
            {
                if (_firstname == value) return;
                _firstname = value;
                OnPropertyChanged("Firstname");
            }
            get => _firstname;
        }

        [MaxLength(18), Column("surname")]
        [JsonProperty(PropertyName = "surname")]
        public string Surname
        {
            set
            {
                if (_surname == value) return;
                _surname = value;
                OnPropertyChanged("Surname");
            }
            get => _surname;
        }

        [MaxLength(32), Unique, Column("email")]
        [JsonProperty(PropertyName = "eMail")]
        public string Email
        {
            set
            {
                if (_email == value) return;
                _email = value;
                OnPropertyChanged("Email");
            }
            get => _email;
        }

        // Used to signalize that type T must be a reference type
        public User()
        {
        }

        public User(string firstname, string surname, string email)
        {
            Firstname = firstname;
            Surname = surname;
            Email = email;
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
