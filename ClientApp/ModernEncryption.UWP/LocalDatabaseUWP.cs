using System;
using System.IO;
using Windows.Storage;
using ModernEncryption.Model;
using ModernEncryption.UWP;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;

[assembly: Xamarin.Forms.Dependency(typeof(LocalDatabaseUwp))]
namespace ModernEncryption.UWP
{
    public class LocalDatabaseUwp : Interfaces.IStorage
    {
        private SQLiteConnectionWithLock _conn;

        private static string GetDatabasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, Constants.LocalDatabaseName);
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(new SQLitePlatformWinRT(), GetDatabasePath());
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => _conn ?? (_conn = new SQLiteConnectionWithLock(new SQLitePlatformWinRT(),
                                                                                 new SQLiteConnectionString(GetDatabasePath(), true))));
            return new SQLiteAsyncConnection(connectionFactory);
        }

        public void DeleteDatabase()
        {
            var path = GetDatabasePath();

            try {
                _conn?.Close();
            } catch {
            }

            if (File.Exists(path)) {
                File.Delete(path);
            }

            _conn = null;
        }

        public void CloseConnection()
        {
            if (_conn == null) return;

            _conn.Close();
            _conn.Dispose();
            _conn = null;

            // Must be called as the disposal of the connection is not released until the GC runs.
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
