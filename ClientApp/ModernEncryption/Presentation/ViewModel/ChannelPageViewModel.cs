using System.Collections.ObjectModel;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ChannelPageViewModel
    {
        private ChannelPage _view;
        public ObservableCollection<Channel> Channels { get; } = new ObservableCollection<Channel>();

        public void SetView(ChannelPage view)
        {
            _view = view;
        }
    }
}
