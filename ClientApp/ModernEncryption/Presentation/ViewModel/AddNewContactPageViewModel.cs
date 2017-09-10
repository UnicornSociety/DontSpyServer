using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    class AddNewContactPageViewModel : INotifyPropertyChanged
    {
        private AddNewContactPage _view;

        public string Title { get; set; } = "AddNewContactPage";
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int Timestamp { get; set; }

        public ICommand BackToContactPageCommand { protected set; get; }

        public AddNewContactPageViewModel()
        {
            this.BackToContactPageCommand = new Command<string>((key) =>
            {
                Debug.WriteLine("Zurück zur ContactPage");
            });

            Surname = "Mustermann";
            Firstname = "Max";
            Sender = 1;
            Receiver = 2;
            Timestamp = 123456;
        }
        public void SetView(AddNewContactPage view)
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
