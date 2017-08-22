using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ModernEncryption.Presentation.View;

namespace ModernEncryption.Presentation.ViewModel
{
    class ErrorPageViewModel : INotifyPropertyChanged
    {
        private ErrorPage _view;

        public string Title { get; set; } = "ErrorPage";
        public event PropertyChangedEventHandler PropertyChanged;
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
