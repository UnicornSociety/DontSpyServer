using System;
using ModernEncryption.Presentation.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption.Presentation.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGroupPage : ContentPage
    {

        public NewGroupPageViewModel NewGroupPageViewModel { get; set; }

        public NewGroupPage(NewGroupPageViewModel viewModel)
        {
            NewGroupPageViewModel = viewModel;

            InitializeComponent();

            viewModel.SetView(this);
            BindingContext = viewModel;
        }

    }
}
