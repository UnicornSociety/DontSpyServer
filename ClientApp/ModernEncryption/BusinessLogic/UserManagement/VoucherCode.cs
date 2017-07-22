using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;
using ModernEncryption.Model;

namespace ModernEncryption.BusinessLogic.UserManagement
{
    class VoucherCode
    {
        public int CreateVoucherCode()
        {
            Random random = new Random();
            return random.Next(1000, 10000);
        }

        public bool SendVoucherCode(int voucherCode)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Constants.NameEMailAddress, Constants.SendingEMailAddress));
            message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "chandler@friends.com"));
            message.Subject = Constants.EMailHeader;

            message.Body = new TextPart("plain")
            {
                Text = Constants.EMailText + voucherCode
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
