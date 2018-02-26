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
	public partial class KeyPage : ContentPage
	{
        public KeyPageViewModel ViewModel { get; }

        public KeyPage()
        {
            InitializeComponent();
            ViewModel = new KeyPageViewModel();
            ViewModel.SetView(this);
            BindingContext = ViewModel;
        }
    }
}