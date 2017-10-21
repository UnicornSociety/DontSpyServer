using System.Collections.ObjectModel;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ChannelsPageViewModel
    {
        private ChannelsPage _view;
        public ObservableCollection<Channel> Channels { get; } = new ObservableCollection<Channel>();
    }
}
