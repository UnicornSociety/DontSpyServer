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
    class ErrorPageViewModel : INotifyPropertyChanged
    {
        private ErrorPage _view;

        public string Title { get; set; } = "ErrorPage";
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand BackToPreviousPageCommand { protected set; get; }
        public ErrorPageViewModel()
        {
            this.BackToPreviousPageCommand = new Command<string>((key) =>
            {
                Debug.WriteLine("Zurück zur vorherigen Seite");
            });
        }

        public void SetView(ErrorPage view)
        {
            _view = view;
        }

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
