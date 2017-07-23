using ModernEncryption.DataAccess;
using ModernEncryption.Interfaces;
using Xamarin.Forms;

namespace ModernEncryption
{
    internal static class DependencyHandler
    {
        private static LocalDatabase _db;

        public static LocalDatabase Db()
        {
            return _db ?? (_db = new LocalDatabase(DependencyService.Get<IStorage>().Path()));
        }
    }
}
