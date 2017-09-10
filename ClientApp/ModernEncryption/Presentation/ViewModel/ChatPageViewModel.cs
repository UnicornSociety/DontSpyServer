using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using ModernEncryption.Model;
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

        public ObservableCollection<Message> Messages { get; }

        public ChatPageViewModel()
        {
            Messages = new ObservableCollection<Message>();

            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
            Messages.Add(new Message(5, 6, 7, 8));
            Messages.Add(new Message(1, 6, 2, 3));
            Messages.Add(new Message(12, 6, 23, 34));
            Messages.Add(new Message(7, 45, 56, 67));
            Messages.Add(new Message(89, 45, 67, 78));
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
