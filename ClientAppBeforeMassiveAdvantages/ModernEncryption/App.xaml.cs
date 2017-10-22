namespace ModernEncryption
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            // DEBUGGING START
            /*CrossSecureStorage.Current.DeleteKey("RegistrationProcess");
            var userService = new UserService();
            var max = new User("Max", "Mustermann", "muster@gmx.de");
            userService.CreateUser(max);//damit ein User angelegt ist auch wenn keine Registration stattgefunden hat
            var test = new List<User>();//um Chat Page als Main Page zu nehmen
            MainPage = new AnchorPage();*/
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
            /*var plainMessage = new DecryptedMessage("krypto", "1", 23535); // Incoming from View: DecryptedMessage obj which is validated
            IEncrypt encryptionLogic = new EncryptionLogic(plainMessage);
            IMessage encryptedMessage = encryptionLogic.Encrypt();
            IMessageService messageService = new MessageService();
            messageService.SendMessage(encryptedMessage);*/

        }

    }
}
