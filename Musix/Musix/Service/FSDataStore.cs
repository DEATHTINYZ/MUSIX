using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Musix.Model;
using Musix.Service;

namespace Musix.Service
{
    public class FSDataStore : IDataStore<Profile>
    {
        FirebaseClient firebase =
            new FirebaseClient("https://musicforyou-3d57b-default-rtdb.firebaseio.com/");
        public async Task<bool> AddItemAsync(Profile item)
        {
            Console.WriteLine(item);
            await firebase
              .Child("Items")
              .PostAsync(item);

            return true;
        }

        public async Task<bool> DeleteItemAsync(string username)
        {
            var toDeletePerson = (await firebase
              .Child("Items")
              .OnceAsync<Profile>()).Where(a => a.Object.Username == username).FirstOrDefault();
            await firebase.Child("Items").Child(toDeletePerson.Key).DeleteAsync();
            return true;
        }

        public async Task<Profile> GetItemAsync(string username)
        {
            Console.WriteLine(username);
            var item = await GetItemsAsync();
            return item.Where(a => a.Username == username).FirstOrDefault();
        }
        public async Task<Profile> GetItemAsyncEmail(string email)
        {
            Console.WriteLine(email);
            var item = await GetItemsAsync();
            return item.Where(a => a.Email == email).FirstOrDefault();
        }
        public async Task<IEnumerable<Profile>> GetItemsAsync(bool forceRefresh = false)
        {
            return (await firebase
              .Child("Items")
              .OnceAsync<Profile>()).Select(item => new Profile
              {
                  Username = item.Object.Username,
                  Password = item.Object.Password,
                  Email = item.Object.Email,
                  ImageFiles = item.Object.ImageFiles
              }).ToList();
        }

        public async Task<bool> UpdateItemAsync(Profile item)
        {
            var toUpdatePerson = (await firebase
              .Child("Items")
              .OnceAsync<Profile>())
              .Where(a => a.Object.Username == item.Username)
              .FirstOrDefault();

            await firebase
              .Child("Items")
              .Child(toUpdatePerson.Key)
              .PutAsync(item);

            return true;
        }
    }

}
