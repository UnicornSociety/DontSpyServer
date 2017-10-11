using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterKeyPage : ContentPage
    {
        private EnterKeyPageViewModel _viewModel;

        public EnterKeyPage()
        {
            InitializeComponent();
            _viewModel = new EnterKeyPageViewModel();
            _viewModel.SetView(this);
            BindingContext = _viewModel;
        }
    }
}