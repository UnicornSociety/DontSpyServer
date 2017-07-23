using System.Windows.Input;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using ModernEncryption.Service;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    internal class RegistrationPageViewModel
    {
        private RegistrationPage _view;
        public ICommand SendVoucherCommand { protected set; get; }

        public RegistrationPageViewModel()
        {
            SendVoucherCommand = new Command<object>(param =>
            {
                var firstname = _view.FindByName<Entry>("firstname").Text;
                var surname = _view.FindByName<Entry>("surname").Text;
                var eMail = _view.FindByName<Entry>("eMail").Text;

                IUserService userService = new UserService();
                var user = new User(firstname, surname, eMail);
                userService.CreateUser(user);
            });
        }


        public void SetView(RegistrationPage view)
        {
            _view = view;
        }
    }
}
