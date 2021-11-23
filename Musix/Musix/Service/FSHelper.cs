using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Firebase.Storage;

namespace Musix.Service
{
    public class FSHelper
    {
        FirebaseStorage firebaseStorage =
    new FirebaseStorage("musicforyou-3d57b.appspot.com");

        public string RootName { get; set; }

        public FSHelper()
        {
            this.RootName = "FileImageUser";
        }

        public async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            var imageUrl = await firebaseStorage
                .Child(RootName)
                .Child(fileName)
                .PutAsync(fileStream);
            return imageUrl;
        }

        public async Task<string> GetFile(string fileName)
        {
            return await firebaseStorage
                .Child(RootName)
                .Child(fileName)
                .GetDownloadUrlAsync();
        }

        public async Task DeleteFile(string fileName)
        {
            await firebaseStorage
                 .Child(RootName)
                 .Child(fileName)
                 .DeleteAsync();

        }
    }
}
