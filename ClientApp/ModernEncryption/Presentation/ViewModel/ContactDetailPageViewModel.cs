using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ModernEncryption.Presentation.ViewModel
{
    class ContactDetailPageViewModel
    {
        public string Title { get; set; } = "ContactDetailPage";

        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Receiver { get; set; }
        public int Sender { get; set; }
        public string EMail { get; set; }

        public ContactDetailPageViewModel()
        {
            Surname = "Mustermann";
            Firstname = "Max";
            Receiver = 1;
            Sender = 2;
            EMail = "max.muster@gmx.net";
        }
    }
}
