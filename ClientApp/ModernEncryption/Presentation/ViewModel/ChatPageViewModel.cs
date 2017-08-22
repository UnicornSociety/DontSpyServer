using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ModernEncryption.Presentation.View;

namespace ModernEncryption.Presentation.ViewModel
{
    class ChatPageViewModel : INotifyPropertyChanged
    {
        private ChatPage _view;

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

        public void SetView(ChatPage view)
        {
            _view = view;
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
