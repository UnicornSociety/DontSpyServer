using System.ComponentModel;
using System.Runtime.CompilerServices;
using ModernEncryption.Interfaces;
using SQLite;

namespace ModernEncryption.Model
{
    public class User : IEntity,INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        // public int Id { get; set; }
        public int Id
        {
            set
            {
                if (Id != value)
                {
                    Id = value;
                    OnPropertyChanged("Color");
                }
            }
            get
            {
                return Id;
            }
        }

        [MaxLength(18), Column("firstname")]
        public string Firstname { get; set; }
        /*public string Firstname
        {
            set
            {
                if (Firstname != value)
                {
                    Firstname = value;
                    OnPropertyChanged("Firstname");
                }
            }
            get
            {
                return Firstname;
            }
        }*/

        [MaxLength(18), Column("surname")]
        public string Surname { get; set; }
       /* public string Surname
        {
            set
            {
                if (Surname != value)
                {
                    Surname = value;
                    OnPropertyChanged("Surname");
                }
            }
            get
            {
                return Surname;
            }
        }*/

        [MaxLength(32), Unique, Column("email")]
        public string Email { get; set; }
        /*public string Email
        {
            set
            {
                if (Email != value)
                {
                    Email = value;
                    OnPropertyChanged("Email");
                }
            }
            get
            {
                return Email;
            }
        }*/

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
