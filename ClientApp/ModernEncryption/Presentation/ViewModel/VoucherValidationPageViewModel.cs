using System.ComponentModel;
using System.Windows.Input;
using ModernEncryption.Presentation.Validation;
using ModernEncryption.Presentation.Validation.Rules;
using ModernEncryption.Presentation.View;
using ModernEncryption.Translations;
using ModernEncryption.Utils;
using Plugin.SecureStorage;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class VoucherValidationPageViewModel : ValidationBase, INotifyPropertyChanged
    {
        private VoucherValidationPage _view;
        private string _title = AppResources.VoucherValidationHeading;
        private ValidatableObject<string> _voucher = new ValidatableObject<string>();
        public ICommand ValidateVoucherCommand { protected set; get; }
        public ICommand ValidateVoucherTextCommand { protected set; get; }

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

        public ValidatableObject<string> Voucher
        {
            get => _voucher;
            set
            {
                if (_voucher == value) return;
                _voucher = value;
                OnPropertyChanged("Voucher");
            }
        }

        public VoucherValidationPageViewModel()
        {
            AddValidations();

            ValidateVoucherCommand = new Command<object>(param =>
            {
                if (!Validate()) return;

                VoucherSucessfullyValidated();
            });

            ValidateVoucherTextCommand = new Command<object>(param =>
            {
                if (!Validate()) return;

                VoucherSucessfullyValidated();
            });
        }

        protected sealed override void AddValidations()
        {
            var voucher = CrossSecureStorage.Current.GetValue("Voucher");

            _voucher.Validations.Add(new StringLengthRule<string>(4, 4) { ValidationMessage = AppResources.ErrorMsgVoucher });
            _voucher.Validations.Add(new EqualsRule<string>(voucher) { ValidationMessage = AppResources.ErrorMsgVoucher });

            var unixTimestampNowValidatable = new ValidatableObject<int> { Value = TimeManagement.UnixTimestampNow };
            unixTimestampNowValidatable.Validations.Add(new WithinNumberRangeRule<int>(
                TimeManagement.UnixTimestampNow, int.Parse(CrossSecureStorage.Current.GetValue(
                    "VoucherExpirationTimestamp")))
            {
                ValidationMessage = AppResources.ErrorMsgVoucherExpired
            });
        }

        private void VoucherSucessfullyValidated()
        {
            CrossSecureStorage.Current.SetValue("VoucherValidated", "true");
            CrossSecureStorage.Current.DeleteKey("Voucher");
            CrossSecureStorage.Current.DeleteKey("VoucherExpirationTimestamp");
            DependencyManager.PullService.PullChannelRequests();
            DependencyManager.PullService.PullNewMessages();

            Application.Current.MainPage = DependencyManager.AnchorPage;
        }

        protected override bool Validate()
        {
            return _voucher.Validate();
        }

        public void SetView(VoucherValidationPage view)
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
