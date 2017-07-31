namespace ModernEncryption.Model
{
    internal class Constants
    {
        public static string RestUrlGetMessage = "http://me.sfzlab.de/ServerApp/api/message/{0}";
        public static string RestUrlSendMessage = "http://me.sfzlab.de/ServerApp/api/message/new";
        public static string RestUrlGetUser = "http://me.sfzlab.de/ServerApp/api/user/{0}";
        public static string RestUrlNewUser = "http://me.sfzlab.de/ServerApp/api/user/new";

        public static string SendingEMailAddress = "noreply@sfzlab.de";
        public static string NameEMailAddress = "ModernEncryption";
        public static string EMailHeader = "Einmaliger Pin zur Verifizierung bei Modern Encryption";
        public static string EMailText = @"Ihr einmaliger PIN ist: ";
        public static string LocalDatabaseName = "kd34167_Crypto";
    }
}
