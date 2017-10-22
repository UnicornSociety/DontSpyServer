using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPageViewModel ViewModel { get; }

        public RegistrationPage()
        {
            InitializeComponent();
            ViewModel = new RegistrationPageViewModel();
            ViewModel.SetView(this);
            BindingContext = ViewModel;
        }
    }
}