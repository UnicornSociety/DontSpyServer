using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;
using ModernEncryption.Service;
using ModernEncryption.Interfaces;
using ModernEncryption.BusinessLogic.Crypto;

namespace ModernEncryption.Presentation.ViewModel
{
    class ChatPageViewModel : INotifyPropertyChanged
    {
        private ChatPage _view;

        public string Title { get; set; } = "ChatPage";
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Receiver { get; set; }
        private Channel _channel;

        public ICommand NewChatoverviewPageCommand { protected set; get; }

        public ICommand SendMessageCommand { protected set; get; }

        public ObservableCollection<Message> Messages { get; }

        public ChatPageViewModel(Channel channel)
        {
            _channel = channel;

            NewChatoverviewPageCommand = new Command<object>(param =>
            {
                _view.Navigation.PushAsync(new ChatOverviewPage(_channel));//TODO nicht sicher ob channel hier der richtige Parameter
            });

            SendMessageCommand = new Command<object>(param =>
            {
                var inputMessage = _view.FindByName<Entry>("inputMessage").Text;
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                var plainMessage = new DecryptedMessage(inputMessage, "1", unixTimestamp);
                IEncrypt encryptionLogic = new EncryptionLogic(plainMessage);
                IMessage encryptedMessage = encryptionLogic.Encrypt();
                IMessageService messageService = new MessageService();
                messageService.SendMessage(encryptedMessage);
            });

            Messages = new ObservableCollection<Message>();

            Messages.Add(new Message("5", 6));
            Messages.Add(new Message("1", 6));
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
