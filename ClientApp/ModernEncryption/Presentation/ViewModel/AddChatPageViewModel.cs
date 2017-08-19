using System.ComponentModel;
using System.Runtime.CompilerServices;
using ModernEncryption.Annotations;

namespace ModernEncryption.Presentation.ViewModel
{
    class AddChatPageViewModel:INotifyPropertyChanged
    {
        public string Title { get; set; } = "AddChatPage";

        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int Timestamp { get; set; }

        public AddChatPageViewModel()
        {
            Surname = "Mustermann";
            Firstname = "Max";
            Sender = 1;
            Receiver = 2;
            Timestamp = 123456;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    }
