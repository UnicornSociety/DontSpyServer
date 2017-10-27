using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VoucherValidationPage : ContentPage
    {
        public VoucherValidationPageViewModel ViewModel { get; }

        public VoucherValidationPage()
        {
            InitializeComponent();
            ViewModel = new VoucherValidationPageViewModel();
            ViewModel.SetView(this);
            BindingContext = ViewModel;
        }
    }
}