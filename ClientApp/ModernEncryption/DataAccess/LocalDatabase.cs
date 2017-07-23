using System.Collections.Generic;
using System.IO;
using ModernEncryption.Interfaces;
using ModernEncryption.Model;
using SQLite;

namespace ModernEncryption.DataAccess
{
    internal class LocalDatabase
    {
        private readonly SQLiteConnection _db;

        public LocalDatabase(string dbPath)
        {
            _db = new SQLiteConnection(Path.Combine(dbPath, Constants.LocalDatabaseName));
            _db.CreateTable<User>();
        }

        public int Save<T>(T obj)
        {
            _db.Insert(obj);
            return ((IEntity)obj).Id;
        }

        public T Get<T>(int primaryKey) where T : new()
        {
            return _db.Get<T>(primaryKey);
        }

        public List<T> Get<T>(string sql) where T : new()
        {
            return _db.Query<T>(sql);
        }

        public int Delete<T>(int primaryKey)
        {
            return _db.Delete<T>(primaryKey);
        }

        public int Delete<T>(T obj)
        {
            return _db.Delete(obj);
        }
    }
}
