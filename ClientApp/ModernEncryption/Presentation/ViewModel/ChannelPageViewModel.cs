using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class ChannelPageViewModel
    {
        private ChannelPage _view;
        public ObservableCollection<Message> Messages { get; } = new ObservableCollection<Message>();
        private Channel Channel { get; }
        public ICommand SendMessageCommand { protected set; get; }

        public ChannelPageViewModel(Channel channel)
        {
            Channel = channel;

            SendMessageCommand = new Command<object>(param =>
            {
                var message = _view.FindByName<Entry>("inputMessage").Text;
                DependencyManager.ChannelService.SendMessage(message, channel);
            });
        }

        public void SetView(ChannelPage view)
        {
            _view = view;
        }
    }
}
