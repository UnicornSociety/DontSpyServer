using System;
using System.Diagnostics;
using MailKit.Net.Smtp;
using MimeKit;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using Plugin.SecureStorage;

namespace ModernEncryption.BusinessLogic.UserManagement
{
    internal class VoucherCode : IVoucherCode
    {
        private readonly int _voucherCode;
        private readonly User _user;

        public VoucherCode(User user)
        {
            _user = user;
            _voucherCode = CreateVoucherCode();
            var voucherTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds + 86400 + 3600;//36600 ist 1h die wir hinter UTC sind in welcher der Timestamp angegeben wird
            CrossSecureStorage.Current.SetValue("VoucherExpirationTimestamp", voucherTimestamp.ToString());
            CrossSecureStorage.Current.SetValue("Voucher", _voucherCode.ToString());
        }

        private int CreateVoucherCode()
        {
            var random = new Random();
            return random.Next(1000, 9999);
        }

        public bool SendVoucherCode()
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(Constants.EmailSenderName, Constants.EmailSenderEmailAddress));
                message.To.Add(new MailboxAddress(_user.Firstname + " " + _user.Surname, _user.Email));
                message.Subject = Constants.EmailSubject;

                message.Body = new TextPart("plain")
                {
                    Text = Constants.EmailBodyBeforePin + _voucherCode
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
            catch // TODO: Improve error management
            {
                Debug.WriteLine("Server antwortet nicht");
                return false;
            }

        }

        public bool ValidateVoucherCode(int userVoucher) // TODO: Use or delete it
        {
            var voucher = Convert.ToInt32(CrossSecureStorage.Current.GetValue("Voucher", "-1"));
            var voucherTimestamp = Convert.ToInt32(CrossSecureStorage.Current.GetValue("VoucherTimestamp", "-1"));
            var currentVoucherTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            if (voucherTimestamp > currentVoucherTimestamp) return false;
            if (voucher != userVoucher) return false;
            CrossSecureStorage.Current.DeleteKey("VoucherTimestamp");
            CrossSecureStorage.Current.DeleteKey("Voucher");
            CrossSecureStorage.Current.SetValue("VoucherValidated", "true");
            return true;
        }
    }

}
