using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Input;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    class ContactDetailPageViewModel : INotifyPropertyChanged
    {
        private ContactDetailPage _view;

        public string Title { get; set; } = "ContactDetailPage";
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Receiver { get; set; }
        public int Sender { get; set; }
        public string EMail { get; set; }

        public ICommand BackToContactPageCommand { protected set; get; }

        public ContactDetailPageViewModel()
        {
            this.BackToContactPageCommand = new Command<string>((key) =>
            {
                Debug.WriteLine("Zurück zur ContactPage");
            });

            Surname = "Mustermann";
            Firstname = "Max";
            Receiver = 1;
            Sender = 2;
            EMail = "max.muster@gmx.net";
        }

        public void SetView(ContactDetailPage view)
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
