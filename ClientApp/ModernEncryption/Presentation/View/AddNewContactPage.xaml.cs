using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewContactPage : ContentPage
    {
        private AddNewContactPageViewModel _viewModel;

        public AddNewContactPage()
        {
            InitializeComponent();
            _viewModel = new AddNewContactPageViewModel();
            _viewModel.SetView(this);
            BindingContext = _viewModel;
        }
    }
}