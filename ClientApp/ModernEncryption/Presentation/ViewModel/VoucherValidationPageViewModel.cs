using System.ComponentModel;
using System.Windows.Input;
using ModernEncryption.Presentation.View;
using ModernEncryption.Translations;
using ModernEncryption.Utils;
using Plugin.SecureStorage;
using Xamarin.Forms;

namespace ModernEncryption.Presentation.ViewModel
{
    public class VoucherValidationPageViewModel : INotifyPropertyChanged
    {
        private VoucherValidationPage _view;
        private string _title = AppResources.VoucherValidationHeading;
        public ICommand ValidateVoucherCommand { protected set; get; }

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

        public VoucherValidationPageViewModel()
        {
            ValidateVoucherCommand = new Command<object>(param =>
            {
                var userInputVoucher = _view.FindByName<Entry>("voucher").Text;
                var voucher = CrossSecureStorage.Current.GetValue("Voucher");
                var voucherExpirationTimestamp = int.Parse(CrossSecureStorage.Current.GetValue("VoucherExpirationTimestamp"));
                if (!userInputVoucher.Equals(voucher) || TimeManagement.UnixTimestampNow > voucherExpirationTimestamp) return; 

                CrossSecureStorage.Current.SetValue("VoucherValidated", "true");
                CrossSecureStorage.Current.DeleteKey("Voucher");
                CrossSecureStorage.Current.DeleteKey("VoucherExpirationTimestamp");
                DependencyManager.PullService.PullChannelRequests();
                DependencyManager.PullService.PullNewMessages();

                Application.Current.MainPage = DependencyManager.AnchorPage;
            });
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
