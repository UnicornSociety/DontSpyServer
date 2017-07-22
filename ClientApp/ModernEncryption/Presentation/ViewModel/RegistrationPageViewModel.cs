using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using ModernEncryption.Interfaces;
using ModernEncryption.Presentation.View;
using ModernEncryption.Service;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    class RegistrationPageViewModel
    {
        public ICommand SendVoucherCommand { protected set; get; }

        public RegistrationPageViewModel()
        {
            SendVoucherCommand = new Command<string>(eMail =>
            {
                IUserService userService = new UserService();
                var user = userService.GetUser(eMail).Result;
                userService.VerifyUser(user);
            });
        }

      
    }
}
