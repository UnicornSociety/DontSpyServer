namespace ModernEncryption.Model
{
    internal class Constants
    {
        public static string RestUrlGetMessage = "http://localhost/api/message/{0}";
        public static string RestUrlSendMessage = "http://localhost/api/message/new";
        public static string RestUrlGetUser = "http://localhost/api/user/{0}";
        public static string RestUrlNewUser = "http://localhost/api/user/new";

        public static string SendingEMailAddress = "noreply@sfzlab.de";
        public static string NameEMailAddress = "ModernEncryption";
        public static string EMailHeader = "Einmaliger Pin zur Verifizierung bei Modern Encryption";
        public static string EMailText = @"Ihr einmaliger PIN ist: ";
    }
}
