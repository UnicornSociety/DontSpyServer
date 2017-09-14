using ModernEncryption.Model;
using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        private ChatPageViewModel _viewModel;

        public ChatPage(Channel channel)
        {
            InitializeComponent();
            _viewModel = new ChatPageViewModel(channel);
            _viewModel.SetView(this);
            BindingContext = _viewModel;
        }
    }
}