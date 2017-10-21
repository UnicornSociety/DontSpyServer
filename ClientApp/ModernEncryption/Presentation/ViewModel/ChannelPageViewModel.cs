using System.Collections.ObjectModel;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ChannelPageViewModel
    {
        private ChannelPage _view;
        public ObservableCollection<Message> Messages { get; } = new ObservableCollection<Message>();
        public Channel Channel { get; set; }

        public void SetView(ChannelPage view)
        {
            _view = view;
        }
    }
}
