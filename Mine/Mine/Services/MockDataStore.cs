using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Chicken Nugget", Description="McDonalds nuggets offer more nutrition", Value = 3},
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Pizza", Description="Holy Grail of School lunches (if ordered from a 3rd party)", Value = 10 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Baked Potato", Description="Codename: The Baked Brick", Value = 2 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Beef Stew", Description="Recipe Requires TopSecret Security Clearance", Value = 7 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Pasta", Description="Often holds at least one lunch lady hair", Value = 1 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Soda", Description="Suitable Alternative to Water", Value = 9 }
            };
        }

        public async Task<bool> CreateAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}