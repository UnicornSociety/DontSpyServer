using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ChannelPageViewModel : INotifyPropertyChanged
    {
        private ChannelPage _view;
        private string _title = "Conversation";
        public ObservableCollection<DecryptedMessage> Messages { get; } = new ObservableCollection<DecryptedMessage>();
        private Channel Channel { get; }
        public ICommand SendMessageCommand { protected set; get; }

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value) return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public ChannelPageViewModel(Channel channel)
        {
            Channel = channel;

            SendMessageCommand = new Command<object>(param =>
            {
                var message = _view.FindByName<Entry>("inputMessage").Text;
                DependencyManager.ChannelService.SendMessage(message, channel);
                _view.FindByName<Entry>("inputMessage").Text = ""; // Clear field
            });
        }

        public void SetView(ChannelPage view)
        {
            _view = view;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
