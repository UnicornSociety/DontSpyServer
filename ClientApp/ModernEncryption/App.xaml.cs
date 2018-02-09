using System.Linq;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using Plugin.SecureStorage;
using SQLiteNetExtensions.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ModernEncryption
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // This lookup NOT required for Windows platforms - the Culture will be automatically set
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                Translations.AppResources.Culture = ci;
                DependencyService.Get<ILocalize>().SetLocale(ci);
            }

            new LocalDatabaseOptions(LocalDatabaseOptions.ConnectionMode.Create);

            DependencyManager.MathematicalMappingLogic.InitalizeIntervalTable();
            DependencyManager.MathematicalMappingLogic.InitalizeTransformationTable();
            // Create reverse table for the transformation table
            MathematicalMappingLogic.BackTransformationTable =
            MathematicalMappingLogic.TransformationTable.ToDictionary(x => x.Value, x => x.Key);

            if (CrossSecureStorage.Current.HasKey("OwnUser"))
            {
                var ownUser = DependencyManager.Database.GetWithChildren<User>(
                    CrossSecureStorage.Current.GetValue("OwnUser"));

                DependencyManager.Me = ownUser;
                DependencyManager.PullService.PullChannelRequests();
                DependencyManager.PullService.PullNewMessages();
                MainPage = DependencyManager.AnchorPage;
            }
            else
            {
                MainPage = new RegistrationPage();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
