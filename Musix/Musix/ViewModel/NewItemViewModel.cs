using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Musix.Model;

namespace Musix.ViewModel
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string description;
        private ObservableCollection<FileImages> imageList;

        public ObservableCollection<FileImages> ImageList
        {
            get => imageList;
            set => SetProperty(ref imageList, value);
        }

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Password
        {
            get => Password;
            set => SetProperty(ref text, value);
        }

        public string Email
        {
            get => Email;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Task<List<string>> TaskA = Task.Run(async () =>
                await CheckAndSaveImage());
            await TaskA.ContinueWith(ac =>
            {
                Profile newItem = new Profile()
                {
                    Username = Guid.NewGuid().ToString(),
                    Password = Password,
                    Email = Email,
                    ImageFiles = ac.Result
                };

                DataStore.AddItemAsync(newItem);

                // This will pop the current page off the navigation stack
                Shell.Current.GoToAsync("..");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);


        }

        private async Task<List<string>> CheckAndSaveImage()
        {
            List<string> UrlString = new List<string>();
            if (ImageList != null && ImageList.Count > 0)
            {
                foreach (var _file in ImageList)
                {
                    UrlString.Add(await SaveFileToServer(_file));
                }
            }
            return UrlString;
        }

        Service.FSHelper fsHelper = new Service.FSHelper();
        private async Task<string> SaveFileToServer(FileImages _file)
        {
            string _uriFile = "";
            var imageAsBytes = ImageSourceToBytes(_file.Image);
            if (imageAsBytes != null)
            {
                using (var streamF = new MemoryStream(imageAsBytes))
                {
                    _uriFile = await fsHelper.UploadFile(streamF, _file.FileName);
                }
            }
            return _uriFile;
        }

        public byte[] ImageSourceToBytes(ImageSource imageSource)
        {
            StreamImageSource streamImageSource = (StreamImageSource)imageSource;
            CancellationToken cancellationToken = CancellationToken.None;
            Task<Stream> task = streamImageSource.Stream(cancellationToken);
            Stream stream = task.Result;
            byte[] bytesAvaiable = new byte[stream.Length];
            stream.Read(bytesAvaiable, 0, bytesAvaiable.Length);
            return bytesAvaiable;
        }

    }
}
