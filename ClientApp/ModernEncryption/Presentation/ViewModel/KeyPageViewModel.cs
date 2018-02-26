using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using ModernEncryption.Translations;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class KeyPageViewModel
    {
        private KeyPage _view;
        private string _title = AppResources.RegistrationHeading;

        public void SetView(KeyPage view)
        {
            _view = view;
        }
    }
    
}
