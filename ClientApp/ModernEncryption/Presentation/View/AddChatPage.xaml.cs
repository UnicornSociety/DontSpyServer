using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddChatPage : ContentPage
	{
	    private AddChatPageViewModel _viewModel;

		public AddChatPage ()
		{
			InitializeComponent ();
            _viewModel = new AddChatPageViewModel();
		    BindingContext = _viewModel;
		}
	}
}
