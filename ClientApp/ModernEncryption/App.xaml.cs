using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MimeKit.Cryptography;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.BusinessLogic.UserManagement;
using ModernEncryption.DataAccess;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using ModernEncryption.Service;
using Plugin.SecureStorage;
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

            new LocalDatabase(LocalDatabase.ConnectionMode.DropAndRecreate);

            var mml = new MathematicalMappingLogic();
            mml.InitalizeIntervalTable();
            mml.InitalizeTransformationTable();

            // Create reverse table for the transformation table
            MathematicalMappingLogic.BackTransformationTable = MathematicalMappingLogic.TransformationTable.ToDictionary(x => x.Value, x => x.Key);

            //Start polling messages
            IRequestorService RequestorService = new RequestorService();
            RequestorService.Start();

            // DEBUGGING START
            CrossSecureStorage.Current.DeleteKey("RegistrationProcess");
            var test = new List<User>();//um Chat Page als Main Page zu nehmen
            MainPage = new RegistrationPage();
            // DEBUGGING END

            /*if (!CrossSecureStorage.Current.HasKey("RegistrationProcess"))
            {
                MainPage = new RegistrationPage();
            } else if (!CrossSecureStorage.Current.HasKey("VoucherProcess"))
            {
                MainPage = new DefinePasswordPage();
            } else
            {
                MainPage = new AnchorPage();
            }*/

            // Input -> Encryption -> Send to server
            var plainMessage = new DecryptedMessage("krypto", "1", 23535); // Incoming from View: DecryptedMessage obj which is validated
            IEncrypt encryptionLogic = new EncryptionLogic(plainMessage);
            IMessage encryptedMessage = encryptionLogic.Encrypt();
            IMessageService messageService = new MessageService();
            messageService.SendMessage(encryptedMessage);
            
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
