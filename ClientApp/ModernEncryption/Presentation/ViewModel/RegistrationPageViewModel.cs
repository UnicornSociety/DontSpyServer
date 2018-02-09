using System.ComponentModel;
using System.Windows.Input;
using ModernEncryption.Model;
using ModernEncryption.Presentation.Validation;
using ModernEncryption.Presentation.Validation.Rules;
using ModernEncryption.Presentation.View;
using ModernEncryption.Translations;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class RegistrationPageViewModel : ValidationBase, INotifyPropertyChanged
    {
        private RegistrationPage _view;
        private string _title = AppResources.RegistrationHeading;
        private ValidatableObject<string> _displayname = new ValidatableObject<string>();
        private ValidatableObject<string> _email = new ValidatableObject<string>();
        public ICommand SendVoucherCommand { protected set; get; }
        public ICommand ValidateDisplaynameCommand { protected set; get; }
        public ICommand ValidateEmailCommand { protected set; get; }

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

        public ValidatableObject<string> Displayname
        {
            get => _displayname;
            set
            {
                if (_displayname == value) return;
                _displayname = value;
                OnPropertyChanged("Displayname");
            }
        }

        public ValidatableObject<string> Email
        {
            get => _email;
            set
            {
                if (_email == value) return;
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public RegistrationPageViewModel()
        {
            AddValidations();

            SendVoucherCommand = new Command<object>(param =>
            {
                if (!Validate()) return;

                var result = DependencyManager.UserService.CreateOwnUser(new User(Displayname.Value, Email.Value));
                if (!result) return;

                Application.Current.MainPage = DependencyManager.AnchorPage;
                DependencyManager.PullService.PullChannelRequests();
                DependencyManager.PullService.PullNewMessages();
            });

            ValidateDisplaynameCommand = new Command<object>(param =>
            {
                ValidateDisplayname();
            });

            ValidateEmailCommand = new Command<object>(param =>
            {
                ValidateEmail();
            });
        }

        protected sealed override void AddValidations()
        {
            _displayname.Validations.Add(new StringLengthRule<string>(3, 30) { ValidationMessage = AppResources.ErrorMsgDisplaynameLength });
            _email.Validations.Add(new StringLengthRule<string>(6, 254) { ValidationMessage = AppResources.ErrorMsgEmailLength });
            _email.Validations.Add(new EmailRule<string> { ValidationMessage = AppResources.ErrorMsgNotEmail });
        }

        protected override bool Validate()
        {
            return ValidateDisplayname() && ValidateEmail();
        }

        private bool ValidateDisplayname()
        {
            return _displayname.Validate();
        }

        private bool ValidateEmail()
        {
            return _email.Validate();
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
