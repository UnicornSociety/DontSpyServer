using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ModernEncryption.Presentation.ViewModel
{
    class ChatPageViewModel:INotifyPropertyChanged
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
