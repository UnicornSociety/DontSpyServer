using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ModernEncryption.Presentation.View;
using ModernEncryption.Service;
using Plugin.SecureStorage;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{

    class DefinePasswordPageViewModel
    {
        private DefinePasswordPage _view;
        public ICommand CheckPasswordCommand { protected get; set; }

        public DefinePasswordPageViewModel()
        {
            CheckPasswordCommand = new Command<object>(param =>
            {
                var userService = new UserService();
                var voucherCode = Int32.Parse(_view.FindByName<Entry>("VoucherCode").Text);
                if (userService.ValidateVoucherCode(voucherCode))
                {
                    CrossSecureStorage.Current.SetValue("VoucherProcess", "1");
                }
                else
                {
                    //Fehlerbehandlung
                }
                var password1 = _view.FindByName<Entry>("password1").Text;
                var password2 = _view.FindByName<Entry>("password2").Text;

                if (password1 == password2)
                {
                    CrossSecureStorage.Current.SetValue("Password", password1.ToString());
                }
            });
        }

        public void SetView(DefinePasswordPage view)
        {
            _view = view;
        }
    }
}

