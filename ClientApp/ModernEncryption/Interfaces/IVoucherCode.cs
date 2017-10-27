namespace ModernEncryption.Interfaces
{
    internal interface IVoucherCode
    {
        bool SendVoucherCode();
        bool ValidateVoucherCode(int userVoucher);
    }
}
