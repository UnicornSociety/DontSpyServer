using System.ComponentModel;
using ModernEncryption.Interfaces;
using SQLite;

namespace ModernEncryption.Model
{
    public class User : IEntity,INotifyPropertyChanged
    {
        private int _id;
        private string _firstname;
        private string _surname;
        private string _email;

        [PrimaryKey, AutoIncrement, Column("id")]
        // public int Id { get; set; }
        public int Id
        {
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
            get
            {
                return _id;
            }
        }

        [MaxLength(18), Column("firstname")]
        public string Firstname
        {
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    OnPropertyChanged("Firstname");
                }
            }
            get
            {
                return _firstname;
            }
        }

        [MaxLength(18), Column("surname")]
       public string Surname
        {
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged("Surname");
                }
            }
            get
            {
                return _surname;
            }
        }

        [MaxLength(32), Unique, Column("email")]
        public string Email
        {
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
            get
            {
                return _email;
            }
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
