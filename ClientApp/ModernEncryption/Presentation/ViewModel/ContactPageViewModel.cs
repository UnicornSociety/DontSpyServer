using System.Diagnostics;
using ModernEncryption.Model;

namespace ModernEncryption.Presentation.ViewModel
{
    internal class ContactPageViewModel
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Receiver { get; set; }
        public int Sender { get; set; }
        public string EMail { get; set; }

        public ContactPageViewModel()
        {
            // Simulation of persist data
            //var primaryKey = DependencyHandler.Db().Save(new User("Tobias", "Straub", "abc@def.de"));
            //Debug.WriteLine(DependencyHandler.Db().Get<User>(primaryKey).Email);

            Surname = "Mustermann";
            Firstname = "Max";
            Receiver = 1;
            Sender = 2;
            EMail = "max.muster@gmx.net";
        }
    }
}
