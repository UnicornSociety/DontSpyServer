using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage: ContentPage
    {
        private ContactPageViewModel _viewModel;

        public ContactPage()
        {
            InitializeComponent();
            _viewModel = new ContactPageViewModel();
            _viewModel.SetView(this);
            BindingContext = _viewModel;
        }
    }
}
