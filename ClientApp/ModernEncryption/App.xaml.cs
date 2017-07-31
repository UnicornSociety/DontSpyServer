using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ModernEncryption.BusinessLogic.Crypto;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using ModernEncryption.Presentation.View;
using ModernEncryption.Service;
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

            MainPage = new AddChatPage();
        }//Muss beim wieder entkommentieren weg

        /*// Input -> Encryption -> Send to server
                    var plainMessage = new DecryptedMessage("krypto", 1, 2, 23535, 3); // Incoming from View: DecryptedMessage obj which is validated
                    IEncrypt encryptionLogic = new EncryptionLogic(plainMessage);
                    IMessage encryptedMessage = encryptionLogic.Encrypt();
                    IMessageService messageService = new MessageService();
                    messageService.SendMessage(encryptedMessage);
        
        
                    // Get from Server -> Decryption -> Output
                    IMessageService messageService2 = new MessageService();
                    var encryptedMessages = messageService2.GetMessage(2).Result; // Incoming from internal drive
                    foreach (var message in encryptedMessages)
                    {
                        IDecrypt decryptionLogic = new DecryptionLogic(message);
                        Debug.WriteLine(decryptionLogic.Decrypt().Text);
                    }
                }
        
                protected override void OnStart()
                {
                    // Handle when your app starts
        
                    var mml = new MathematicalMappingLogic();
                    mml.InitalizeIntervalTable();
                    mml.InitializeKeyTable();
                    mml.InitalizeTransformationTable();
        
                    // Create reverse table for the transformation table
                    MathematicalMappingLogic.BackTransformationTable = MathematicalMappingLogic.TransformationTable.ToDictionary(x => x.Value, x => x.Key);
        
                }
        
                protected override void OnSleep()
                {
                    // Handle when your app sleeps
                }
        
                protected override void OnResume()
                {
                    // Handle when your app resumes
                }*/
        
    }
}
