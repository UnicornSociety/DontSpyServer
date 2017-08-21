using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        private ChatPageViewModel _viewModel;

        public ChatPage()
        {
            InitializeComponent();
            _viewModel = new ChatPageViewModel();
            _viewModel.SetView(this);
            BindingContext = _viewModel;
        }
    }
}