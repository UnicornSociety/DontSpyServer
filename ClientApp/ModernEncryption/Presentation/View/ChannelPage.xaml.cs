using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChannelPage : ContentPage
	{
	    public ChannelPageViewModel ViewModel { get; }

        public ChannelPage ()
		{
			InitializeComponent ();
		    ViewModel = new ChannelPageViewModel();
		    ViewModel.SetView(this);
		    BindingContext = ViewModel;
        }
	}
}