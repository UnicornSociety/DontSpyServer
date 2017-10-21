using System.Collections.ObjectModel;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ChannelsPageViewModel
    {
        private ChannelsPage _view;
        public ObservableCollection<Channel> Channels { get; } = new ObservableCollection<Channel>();
        public ICommand NewSingleChannelCommand { protected set; get; }
        public ICommand NewGroupChannelCommand { protected set; get; }
        public ICommand TabbedChannelCommand { protected set; get; }

        public ChannelsPageViewModel()
        {
            // Load all channels from local database
            foreach (var channel in DependencyManager.ChannelService.LoadChannels()) Channels.Add(channel);

            NewSingleChannelCommand = new Command<object>(param =>
            {
                _view.Navigation.PushAsync(DependencyManager.ContactsPage);
            });

            NewGroupChannelCommand = new Command<object>(param =>
            {
                _view.Navigation.PushAsync(DependencyManager.ContactsPage);
            });

            TabbedChannelCommand = new Command<object>(param =>
            {
                _view.Navigation.PushAsync(((Channel)param).View);
            });
        }

        public void SetView(ChannelsPage view)
        {
            _view = view;
        }
    }
}
