using System.Diagnostics;
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

            // DEBUGGING START
            CrossSecureStorage.Current.SetValue("VoucherValidated", "true"); // TODO: DELETE THIS, IT'S A DEBUGGING FLAG
            //CrossSecureStorage.Current.DeleteKey("OwnUser"); // TODO: DELETE THIS, IT'S A DEBUGGING FLAG
            // DEBUGGING END

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
                // TODO: Else MainPage=EnterVoucherPage and then pull to channel and new messages
            }
            else
            {
                MainPage = new RegistrationPage();
            }

            // DEBUGGING
            foreach (var channel in DependencyManager.Database.GetAllWithChildren<Channel>(recursive: true))
            {
                Debug.WriteLine("Channel: " + channel.Id);
            }

            foreach (var user in DependencyManager.Database.GetAllWithChildren<User>(recursive: true))
            {
                Debug.WriteLine("User: " + user.Id);
            }

            foreach (var message in DependencyManager.Database.GetAllWithChildren<Message>(recursive: true))
            {
                Debug.WriteLine("Message: " + message.Id);
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
