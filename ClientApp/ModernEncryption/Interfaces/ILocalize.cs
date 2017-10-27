using System.Globalization;

namespace ModernEncryption.Interfaces
{
    internal interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
