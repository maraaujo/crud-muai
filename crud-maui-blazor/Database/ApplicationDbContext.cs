using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using crud_maui_blazor.Models;

namespace crud_maui_blazor.Database
{
    public class ApplicationDbContext
    {
        private readonly SQLiteAsyncConnection _dbConnection;
        private const string NamespacePrefix = "crud_maui_blazor.Database.";
        private const string DatabaseFileName = "crud-maui-blazor.db3";

        private static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);

        private const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite |
                                              SQLiteOpenFlags.Create |
                                              SQLiteOpenFlags.SharedCache;

        public ApplicationDbContext()
        {
            _dbConnection ??= new SQLiteAsyncConnection(DatabasePath, Flags);
            _dbConnection.CreateTableAsync<Perfume>().Wait(); // Troque por migrations em produção
        }

        public async Task<int> Create<T>(T entity) where T : class
        {
            return await _dbConnection.InsertAsync(entity);
        }

        public async Task<int> Update<T>(T entity) where T : class
        {
            return await _dbConnection.UpdateAsync(entity);
        }

        public async Task<int> Delete<T>(T entity) where T : class
        {
            return await _dbConnection.DeleteAsync(entity);
        }

        public async Task<List<T>> GetTableRows<T>() where T : class, new()
        {
            return await _dbConnection.Table<T>().ToListAsync();
        }

        public async Task<T?> GetTableRow<T>(Func<T, bool> predicate) where T : class, new()
        {
            var rows = await _dbConnection.Table<T>().ToListAsync();
            return rows.FirstOrDefault(predicate);
        }


        public async Task<int> AddOrUpdateAsync<T>(T entity) where T : class
        {
            return await _dbConnection.InsertOrReplaceAsync(entity);
        }
    }
}
