using ModernEncryption.Interfaces;
using SQLite.Net;
using Xamarin.Forms;

namespace ModernEncryption
{
    internal class DependencyManager
    {
        public static SQLiteConnection Database { get; } = DependencyService.Get<IStorage>().GetConnection();
    }
}
