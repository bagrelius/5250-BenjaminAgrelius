using Mine.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mine.Services
{
    public class DatabaseService : IDataStore<ItemModel>
    {

        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public DatabaseService()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ItemModel).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(ItemModel)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        /// <summary>
        /// Inserts item into the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if item is inserted</returns>
        public async Task<bool> CreateAsync(ItemModel item)
        {
            if (item == null)
            {
                return false;
            }
            //Returns the ID of the inserted Item, 0 if fail
            var result = await Database.InsertAsync(item);
            if (result == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Updates Item with correspinding Id, fails if not found
        /// </summary>
        /// <param name="item"></param>
        /// <returns>returns true if successful </returns>
        public async Task<bool> UpdateAsync(ItemModel item)
        {
            if (item == null)
            {
                return false;
            }

            var result = await Database.UpdateAsync(item);
            if (item == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Deletes item from database corresponding to the id passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if deleted successfully</returns>
        public async Task<bool> DeleteAsync(string id)
        {
            //Cant delete if not there
            var data = await ReadAsync(id);
            if (data == null)
            {
                return false;
            }

            //Delete item from database
            var result = await Database.DeleteAsync(data);
            if (result == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Searches Database for corresponding id passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns id if successfully found</returns>
        public Task<ItemModel> ReadAsync(string id)
        {

            if (id == null)
            {
                return null;
            }

            //Call Database to read Id
            //Find First Id that matched the id passed in
            var result = Database.Table<ItemModel>().FirstOrDefaultAsync(m => m.Id.Equals(id));

            return result;

        }

        public async Task<IEnumerable<ItemModel>> IndexAsync(bool forceRefresh = false)
        {
            //Fetching the list of items form the database
            var result = await Database.Table<ItemModel>().ToListAsync();
            return result;
        }
    }
}
