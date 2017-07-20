using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGroupPage : ContentPage
    {
        private AddGroupPageViewModel _viewModel;

        public AddGroupPage()
        {
            InitializeComponent();
            _viewModel = new AddGroupPageViewModel();
            BindingContext = _viewModel;
        }
    }
}