using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace URLShortenerDAL
{
    public abstract class BaseRepository
    {
        protected readonly string _connectionString;
        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string query, object entity)
        {
            using (IDbConnection db = new SQLiteConnection(_connectionString))
            {
                var result = await db.QueryAsync<T>(query, entity);
                return result;
            }
        }

        protected async Task ExecuteAsync(string query, object entity)
        {
            using (IDbConnection db = new SQLiteConnection(_connectionString))
            {
                var result = await db.ExecuteAsync(query, entity);
            }
        }
    }
}
