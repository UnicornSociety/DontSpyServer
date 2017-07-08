namespace ModernEncryption.Model
{
    internal class User
    {
        public string Firstname { get; }
        public string Surname { get; }
        public string Email { get; }

        public User(string firstname, string surname, string email)
        {
            Firstname = firstname;
            Surname = surname;
            Email = email;
        }
    }
}
