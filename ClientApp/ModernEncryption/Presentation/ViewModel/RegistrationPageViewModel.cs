using System.ComponentModel;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class RegistrationPageViewModel : INotifyPropertyChanged
    {
        private RegistrationPage _view;
        private string _title = "Registration";
        public ICommand SendVoucherCommand { protected set; get; }

        public string Title
        {
            get => _title;
            set
            {
                if (_title == value) return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public RegistrationPageViewModel()
        {
            SendVoucherCommand = new Command<object>(param =>
            {
                var firstname = _view.FindByName<Entry>("firstname").Text;
                var surname = _view.FindByName<Entry>("surname").Text;
                var eMail = _view.FindByName<Entry>("eMail").Text;
                var result = DependencyManager.UserService.CreateOwnUser(new User(firstname, surname, eMail));

                if (result)
                    Application.Current.MainPage = new VoucherValidationPage();
            });
        }

        public void SetView(RegistrationPage view)
        {
            _view = view;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
