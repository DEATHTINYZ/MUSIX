using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Musix.Service
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string username);
        Task<T> GetItemAsyncEmail(string email);
        Task<T> GetItemAsync(string username);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
