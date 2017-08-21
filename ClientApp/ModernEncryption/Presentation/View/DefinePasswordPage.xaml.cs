using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DefinePasswordPage : ContentPage
	{
	    private DefinePasswordPageViewModel _viewModel;

	    public DefinePasswordPage ()
		{
            InitializeComponent();
            _viewModel = new DefinePasswordPageViewModel();
            _viewModel.SetView(this);
            BindingContext = _viewModel;
        }
	}
}