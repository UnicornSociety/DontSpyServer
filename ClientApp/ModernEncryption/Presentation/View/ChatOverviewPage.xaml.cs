using System.Collections.ObjectModel;
using ModernEncryption.Model;
using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatOverviewPage : ContentPage
    {
        private ChatOverviewPageViewModel _viewModel;

        public ChatOverviewPage(Channel channel)
        {
            InitializeComponent();
            _viewModel = new ChatOverviewPageViewModel(channel);
            _viewModel.SetView(this);
            BindingContext = _viewModel;
        }
        
    }
}
