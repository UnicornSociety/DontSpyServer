using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        private RegistrationPageViewModel _viewModel;

        public RegistrationPage()
        {
            InitializeComponent();
            _viewModel = new ViewModel.RegistrationPageViewModel();
            BindingContext = _viewModel;
        }
    }
}
