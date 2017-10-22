using System.Linq;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Presentation.View;
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

            var mml = new MathematicalMappingLogic();
            mml.InitalizeIntervalTable();
            mml.InitalizeTransformationTable();
            // Create reverse table for the transformation table
            MathematicalMappingLogic.BackTransformationTable =
            MathematicalMappingLogic.TransformationTable.ToDictionary(x => x.Value, x => x.Key);


            DependencyManager.ChannelService.PullChannelRequests();
            DependencyManager.ChannelService.PullNewMessages();

            /*var channel = new Channel(123, new List<User> { new User("Tobias", "Straub", "hello@tobiasstraub.com") }, new Message(53553, "hh", "msg"));
            DependencyManager.Database.InsertWithChildren(channel);
            var x = DependencyManager.Database.GetAllWithChildren<Channel>(recursive:true);
            var y = DependencyManager.Database.GetAllWithChildren<User>(recursive: true);
            var z = DependencyManager.Database.GetAllWithChildren<Message>(recursive: true);*/

            MainPage = new AnchorPage();
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
