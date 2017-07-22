using System.Collections.ObjectModel;
using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatOverview : ContentPage
    {
        private ChatOverviewViewModel _viewModel;

        public ChatOverview()
        {
            InitializeComponent();
            _viewModel = new ChatOverviewViewModel();
            BindingContext = _viewModel;
        }

        public string Surname { get; set; }
        public static ObservableCollection<ChatOverview> ItemsSource { get; set; }
    }
}
