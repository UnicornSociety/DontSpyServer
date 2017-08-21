using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage: ContentPage
    {
        private ContactDetailPageViewModel _viewModel;

        public ContactDetailPage()
        {
            InitializeComponent();
            _viewModel = new ContactDetailPageViewModel();
            _viewModel.SetView(this);
            BindingContext = _viewModel;
        }
    }
}