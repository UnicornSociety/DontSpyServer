using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    class RegistrationPageViewModel
    {
        public ICommand VerificationCommand { protected set; get; }

        public RegistrationPageViewModel()
        {
            this.VerificationCommand = new Command<string>((key) =>
            {
                Debug.WriteLine("Hallo Helmut");
            });
        }

      
    }
}
