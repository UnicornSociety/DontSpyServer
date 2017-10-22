using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginPageViewModel _viewModel;

        public LoginPage()
        {
            InitializeComponent();
            _viewModel = new LoginPageViewModel();
            _viewModel.SetView(this);
            BindingContext = _viewModel;
        }
    }
}