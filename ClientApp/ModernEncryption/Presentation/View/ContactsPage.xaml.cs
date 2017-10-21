using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactsPage : ContentPage
	{
	    public ContactsPageViewModel ViewModel { get; }

        public ContactsPage ()
		{
			InitializeComponent ();
		    ViewModel = new ContactsPageViewModel();
		    ViewModel.SetView(this);
		    BindingContext = ViewModel;
        }
	}
}