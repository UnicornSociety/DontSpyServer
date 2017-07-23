using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        private readonly RegistrationPageViewModel _viewModel;

        public RegistrationPage()
        {
            InitializeComponent();
            _viewModel = new RegistrationPageViewModel();
            _viewModel.SetView(this);
            BindingContext = _viewModel;
        }

    }
}
