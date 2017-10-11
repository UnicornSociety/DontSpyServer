using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ModernEncryption.Presentation.View;

namespace ModernEncryption.Presentation.ViewModel
{
    class EnterKeyPageViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; } = "EnterKeyPage";
        private EnterKeyPage _view;

        public void SetView(EnterKeyPage view)
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
