using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorPage : ContentPage
    {
        private ErrorPageViewModel _viewModel;

        public ErrorPage()
        {
            InitializeComponent();
            _viewModel = new ErrorPageViewModel();
            _viewModel.SetView(this);
            BindingContext = _viewModel;
        }
    }
}