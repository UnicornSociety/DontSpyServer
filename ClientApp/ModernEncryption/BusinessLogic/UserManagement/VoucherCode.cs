using System;
using MailKit.Net.Smtp;
using MimeKit;
using ModernEncryption.Model;
using Plugin.SecureStorage;

namespace ModernEncryption.BusinessLogic.UserManagement
{
    internal class VoucherCode
    {
        private readonly int _voucherCode;
        private readonly User _user;

        public VoucherCode(User user)
        {
            _user = user;
            _voucherCode = CreateVoucherCode();
            CrossSecureStorage.Current.SetValue("Voucher", _voucherCode.ToString());
        }

        private int CreateVoucherCode()
        {
            var random = new Random();
            return random.Next(1000, 10000);
        }

        public bool SendVoucherCode()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Constants.NameEMailAddress, Constants.SendingEMailAddress));
            message.To.Add(new MailboxAddress(_user.Firstname + " " + _user.Surname, _user.Email));
            message.Subject = Constants.EMailHeader;

            message.Body = new TextPart("plain")
            {
                Text = Constants.EMailText + _voucherCode
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.friends.com", 587, false); //TODO: Port; SSL unterstützt?

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("joey", "password");

                client.Send(message);
                client.Disconnect(true);
            }
            return true;
        }
    }

}
