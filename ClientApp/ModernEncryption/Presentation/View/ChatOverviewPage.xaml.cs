using System.Collections.ObjectModel;
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
            BindingContext = _viewModel;
        }

        public string Surname { get; set; }
        public static ObservableCollection<ChatOverviewPage> ItemsSource { get; set; }
    }
}
