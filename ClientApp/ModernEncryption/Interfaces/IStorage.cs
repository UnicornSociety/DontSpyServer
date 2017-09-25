using SQLite.Net;
using SQLite.Net.Async;

namespace ModernEncryption.Interfaces
{
    public interface IStorage
    {
        void CloseConnection();
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetAsyncConnection();
        void DeleteDatabase();
    }
}
