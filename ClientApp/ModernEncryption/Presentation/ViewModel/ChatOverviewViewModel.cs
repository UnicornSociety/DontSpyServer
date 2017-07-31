using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    class ChatOverviewViewModel 
    {
        public string Title { get; set; } = "ChatOverview";

        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int Timestamp { get; set; }
       
        public ChatOverviewViewModel()
        {
            Surname = "Mustermann";
            Firstname = "Max";
            Sender = 1;
            Receiver = 2;
            Timestamp = 123456;
        }

    }
}
