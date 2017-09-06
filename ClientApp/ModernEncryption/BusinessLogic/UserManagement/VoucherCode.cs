using System;
using System.Diagnostics;
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
            Int32 VoucherTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + 86400;
            CrossSecureStorage.Current.SetValue("VoucherTimestamp", VoucherTimestamp.ToString());
            CrossSecureStorage.Current.SetValue("Voucher", _voucherCode.ToString());
        }

        private int CreateVoucherCode()
        {
            var random = new Random();
            return random.Next(1000, 10000);
        }

        public bool SendVoucherCode()
        {
            try
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
                    client.Connect("mail.sfzlab.de", 25, false);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate("noreply@sfzlab.de", "ModernEncryption");
                    client.Send(message);
                    client.Disconnect(true);
                }
                return true;
            }

            catch
            {
                Debug.WriteLine("Server antwortet nicht");
                return false;
            }
           
        }
    }

}
