using ModernEncryption.Interfaces;
using SQLite;

namespace ModernEncryption.Model
{
    public class User : IEntity
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        [MaxLength(18), Column("firstname")]
        public string Firstname { get; set; }
        [MaxLength(18), Column("surname")]
        public string Surname { get; set; }
        [MaxLength(32), Unique, Column("email")]
        public string Email { get; set; }

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
    }
}
