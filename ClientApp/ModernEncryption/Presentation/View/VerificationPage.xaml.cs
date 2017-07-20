using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerificationPage : ContentPage
    {
        private VerificationPageViewModel _viewModel;

        public VerificationPage()
        {
            InitializeComponent();
            _viewModel = new VerificationPageViewModel();
            BindingContext = _viewModel;
        }
    }
}
