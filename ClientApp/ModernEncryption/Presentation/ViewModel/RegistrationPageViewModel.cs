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
        private ValidatableObject<string> _firstname = new ValidatableObject<string>();
        private ValidatableObject<string> _surname = new ValidatableObject<string>();
        private ValidatableObject<string> _email = new ValidatableObject<string>();
        public ICommand SendVoucherCommand { protected set; get; }
        public ICommand ValidateFirstnameCommand { protected set; get; }
        public ICommand ValidateSurnameCommand { protected set; get; }
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

        public ValidatableObject<string> Firstname
        {
            get => _firstname;
            set
            {
                if (_firstname == value) return;
                _firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        public ValidatableObject<string> Surname
        {
            get => _surname;
            set
            {
                if (_surname == value) return;
                _surname = value;
                OnPropertyChanged("Surname");
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

                var result = DependencyManager.UserService.CreateOwnUser(new User(Firstname.Value, Surname.Value, Email.Value));
                if (!result) return;

                Application.Current.MainPage = DependencyManager.AnchorPage;
                DependencyManager.PullService.PullChannelRequests();
                DependencyManager.PullService.PullNewMessages();
            });

            ValidateFirstnameCommand = new Command<object>(param =>
            {
                ValidateFirstname();
            });

            ValidateSurnameCommand = new Command<object>(param =>
            {
                ValidateSurname();
            });

            ValidateEmailCommand = new Command<object>(param =>
            {
                ValidateEmail();
            });
        }

        protected sealed override void AddValidations()
        {
            _firstname.Validations.Add(new StringLengthRule<string>(3, 30) { ValidationMessage = AppResources.ErrorMsgFirstnameLength });
            _surname.Validations.Add(new StringLengthRule<string>(3, 30) { ValidationMessage = AppResources.ErrorMsgSurnameLength });
            _email.Validations.Add(new StringLengthRule<string>(6, 254) { ValidationMessage = AppResources.ErrorMsgEmailLength });
            _email.Validations.Add(new EmailRule<string> { ValidationMessage = AppResources.ErrorMsgNotEmail });
        }

        protected override bool Validate()
        {
            return ValidateFirstname() && ValidateSurname() && ValidateEmail();
        }

        private bool ValidateFirstname()
        {
            return _firstname.Validate();
        }

        private bool ValidateSurname()
        {
            return _surname.Validate();
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
