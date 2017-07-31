using System;
using System.Collections.Generic;
using System.Text;

namespace ModernEncryption.Presentation.ViewModel
{
    class ChatPageViewModel
    {
        public string Title { get; set; } = "ChatPage";

        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Receiver { get; set; }

        public ChatPageViewModel()
        {
            Surname = "Mustermann";
            Firstname = "Max";
            Receiver = 1;
        }
    }
}
