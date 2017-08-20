using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ModernEncryption.Presentation.ViewModel
{
    class ErrorPageViewModel:INotifyPropertyChanged
    {
        public string Title { get; set; } = "ErrorPage";
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
