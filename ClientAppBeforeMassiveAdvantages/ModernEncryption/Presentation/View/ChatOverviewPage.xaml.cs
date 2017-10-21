using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatOverviewPage : ContentPage
    {
        private ChatOverviewPageViewModel _viewModel;

        public ChatOverviewPage()
        {
            InitializeComponent();
            _viewModel = new ChatOverviewPageViewModel();
            _viewModel.SetView(this);
            BindingContext = _viewModel;
        }

    }
}