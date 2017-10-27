using System.Linq;
using ModernEncryption.BusinessLogic.Crypto;
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
            new LocalDatabaseOptions(LocalDatabaseOptions.ConnectionMode.Create);

            var mml = new MathematicalMappingLogic();
            mml.InitalizeIntervalTable();
            mml.InitalizeTransformationTable();
            // Create reverse table for the transformation table
            MathematicalMappingLogic.BackTransformationTable =
            MathematicalMappingLogic.TransformationTable.ToDictionary(x => x.Value, x => x.Key);

            if (CrossSecureStorage.Current.HasKey("OwnUser"))
            {
                var ownUser = DependencyManager.Database.GetWithChildren<User>(
                    CrossSecureStorage.Current.GetValue("OwnUser"));

                DependencyManager.Me = ownUser;

                if (CrossSecureStorage.Current.HasKey("VoucherValidated"))
                {
                    MainPage = DependencyManager.AnchorPage;
                    DependencyManager.ChannelService.PullChannelRequests();
                    DependencyManager.ChannelService.PullNewMessages();
                }
                else
                {
                    MainPage = new VoucherValidationPage();
                }
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
