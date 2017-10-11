using System;
using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGroupPage : ContentPage
    {

        public ContactPageViewModel ContactPageViewModel { get; set; }

        public NewGroupPage(ContactPageViewModel viewModel)
        {
            ContactPageViewModel = viewModel;

            InitializeComponent();

            viewModel.SetView(this);
            BindingContext = viewModel;
        }

    }
}
