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
            new LocalDatabaseOptions(LocalDatabaseOptions.ConnectionMode.DropAndRecreate);

            CrossSecureStorage.Current.SetValue("VoucherValidated", "true"); // TODO: DELETE THIS, IT'S A DEBUGGING FLAG
            //CrossSecureStorage.Current.DeleteKey("OwnUser"); // TODO: DELETE THIS, IT'S A DEBUGGING FLAG

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
                // TODO: Else MainPage=EnterVoucherPage
            }
            else
            {
                MainPage = new RegistrationPage();
            }


            

            /*var channel = new Channel(123, new List<User> { new User("Tobias", "Straub", "hello@tobiasstraub.com") }, new Message(53553, "hh", "msg"));
            DependencyManager.Database.InsertWithChildren(channel);
            var x = DependencyManager.Database.GetAllWithChildren<Channel>(recursive:true);
            var y = DependencyManager.Database.GetAllWithChildren<User>(recursive: true);
            var z = DependencyManager.Database.GetAllWithChildren<Message>(recursive: true);*/
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
