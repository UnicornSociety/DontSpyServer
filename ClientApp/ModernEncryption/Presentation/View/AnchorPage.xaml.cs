using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnchorPage : TabbedPage
    {
        private AnchorPageViewModel _viewModel;

        public AnchorPage()
        {
            InitializeComponent();
            _viewModel = new AnchorPageViewModel();
            //_viewModel.SetView(this);
            BindingContext = _viewModel;
        }
    }
}
