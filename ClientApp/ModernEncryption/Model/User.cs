using System.Collections.Generic;
using System.ComponentModel;
using ModernEncryption.Interfaces;
using Newtonsoft.Json;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ModernEncryption.Model
{
    [Table("User")]
    public class User : IEntity, INotifyPropertyChanged
    {
        private int _id;
        private string _firstname;
        private string _surname;
        private string _email;

        [PrimaryKey, AutoIncrement, JsonIgnore]
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

        [MaxLength(18), JsonProperty(PropertyName = "firstname")]
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

        [MaxLength(18), JsonProperty(PropertyName = "surname")]
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

        [MaxLength(32), Unique, JsonProperty(PropertyName = "eMail")]
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

        [ManyToMany(typeof(UserChannel)), JsonIgnore]
        public List<Channel> Channels { get; set; }

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
