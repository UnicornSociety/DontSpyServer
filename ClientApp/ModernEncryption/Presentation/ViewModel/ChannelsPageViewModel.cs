using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ChannelsPageViewModel : INotifyPropertyChanged
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
                DependencyManager.AnchorPage.Children[1].Navigation.PopToRootAsync(true);
                DependencyManager.AnchorPage.CurrentPage = DependencyManager.AnchorPage.Children[1]; // Switch tab
            });

            NewGroupChannelCommand = new Command<object>(param =>
            {
                // Hack, because layout do not update by changing visibility status
                var anchorPageContactsChild = DependencyManager.AnchorPage.Children[1];
                DependencyManager.AnchorPage.Children.RemoveAt(1);
                DependencyManager.ContactsPage.ViewModel.ActivateMultipleSelectionSupport();
                DependencyManager.AnchorPage.Children.Add(anchorPageContactsChild);
                DependencyManager.AnchorPage.CurrentPage = DependencyManager.AnchorPage.Children[1]; // Switch tab

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
