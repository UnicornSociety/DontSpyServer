using ModernEncryption.Translations;

namespace ModernEncryption.Model
{
    public class Constants
    {
        public static string RestUrlGetMessage = "http://me.sfzlab.de/api/message/{0}";
        public static string RestUrlSendMessage = "http://me.sfzlab.de/api/message/new";
        public static string RestUrlUpdateMessageProcessingCounter = "http://me.sfzlab.de/api/message/processed/{0}";
        public static string RestUrlDeleteMessage = "http://me.sfzlab.de/api/message/{0}";
        public static string RestUrlGetUser = "http://me.sfzlab.de/api/user/{0}";
        public static string RestUrlNewUser = "http://me.sfzlab.de/api/user/new";

        public static string EmailSenderEmailAddress = "noreply@sfzlab.de";
        public static string EmailSenderName = AppResources.VoucherValidationEmailSenderName;
        public static string EmailSubject = AppResources.VoucherValidationEmailSubject;
        public static string EmailBodyBeforePin = AppResources.VoucherValidationEmailBodyBeforePin;
        public static string LocalDatabaseName = "dontSpy";
    }
}
