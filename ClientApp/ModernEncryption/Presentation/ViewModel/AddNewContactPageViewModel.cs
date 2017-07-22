using System;
using System.Collections.Generic;
using System.Text;

namespace ModernEncryption.Presentation.ViewModel
{
    class AddNewContactPageViewModel
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int Timestamp { get; set; }

        public AddNewContactPageViewModel()
        {
            Surname = "Mustermann";
            Firstname = "Max";
            Sender = 1;
            Receiver = 2;
            Timestamp = 123456;
        }
    }
}
