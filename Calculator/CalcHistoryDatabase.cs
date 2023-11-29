using SQLite;

namespace Calculator
{
    public static class Constants
    {
        public const string DatabaseFilename = "CalcHistoryDB.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }

    public class CalcHistoryDatabase
    {
        SQLiteAsyncConnection Database;

        public CalcHistoryDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<CalcHistoryModel>();
        }

        public async Task<List<CalcHistoryModel>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<CalcHistoryModel>().ToListAsync();
        }

        public async Task DeleteItemsAsync()
        {
            await Database.DeleteAllAsync<CalcHistoryModel>();
        }

        public async Task<int> SaveItemAsync(CalcHistoryModel item)
        {
            await Init();
            //if (item.ID != 0)
            //    return await Database.UpdateAsync(item);
            //else

            return await Database.InsertAsync(item);
        }

    }
}