using System;
using System.Collections.Generic;
using System.Text;
using ModernEncryption.Presentation.View;

namespace ModernEncryption.Presentation.ViewModel
{
    class LoginPageViewModel
    {
        public string Title { get; set; } = "LoginPage";
        private LoginPage _view;

        public void SetView(LoginPage view)
        {
            _view = view;
        }
    }
}
