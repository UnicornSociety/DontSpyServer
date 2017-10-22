namespace ModernEncryption.Model
{
    public class Constants
    {
        public static string RestUrlGetMessage = "http://me.sfzlab.de/api/message/{0}";
        public static string RestUrlSendMessage = "http://me.sfzlab.de/api/message/new";
        public static string RestUrlDeleteMessage = "http://me.sfzlab.de/api/message/{0}";
        public static string RestUrlGetUser = "http://me.sfzlab.de/api/user/{0}";
        public static string RestUrlNewUser = "http://me.sfzlab.de/api/user/new";

        public static string SendingEMailAddress = "noreply@sfzlab.de";
        public static string NameEMailAddress = "ModernEncryption";
        public static string EMailHeader = "Einmaliger Pin zur Verifizierung bei Modern Encryption";
        public static string EMailText = @"Ihr einmaliger PIN ist: ";
        public static string LocalDatabaseName = "kd34167_Crypto";
    }
}
