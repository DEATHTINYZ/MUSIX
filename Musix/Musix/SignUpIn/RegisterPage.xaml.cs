using Firebase.Auth;
using Musix.Model;
using Musix.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Musix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class RegisterPage : ContentPage
    {
        public Profile Profile { get; set; }
        private ObservableCollection<FileImages> imageList;
        NewItemViewModel ns = new NewItemViewModel();
        NewItemViewModel _viewModel;
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NewItemViewModel(); // Referent Type

            _viewModel.ImageList = new Obsevablecollection<FileImages>();
        }

        private void Go_Back(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
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
        private async Task<List<string>> CheckAndSaveImage()
        {
            List<string> UrlString = new List<string>();
            if (ns.ImageList != null && ns.ImageList.Count > 0)
            {
                foreach (var _file in ns.ImageList)
                {
                    UrlString.Add(await SaveFileToServer(_file));
                }
            }
            return UrlString;
        }
        async void SignUp(System.Object sender, System.EventArgs e)
        {
            Task<List<string>> TaskA = Task.Run(async () =>
                await CheckAndSaveImage());
            await TaskA.ContinueWith(async ac =>
            {
                Profile SaveProfile = new Profile()
                {
                    Username = Usernames.Text,
                    Password = Passwords.Text,
                    Email = Emails.Text,

                };
                var UserCheck = await LoginPage.DataStore.GetItemAsync(Usernames.Text);
                var EmailCheck = await LoginPage.DataStore.GetItemAsyncEmail(Emails.Text);

                if (Usernames.Text == null && Passwords.Text == null && Emails.Text == null)
                {
                    await DisplayAlert("Alert", "Please fill information", "OK");
                }
                if (UserCheck == null && EmailCheck == null)
                {
                    await LoginPage.DataStore.AddItemAsync(SaveProfile);
                    Application.Current.MainPage = new LoginPage();
                }
                else
                {
                    if (UserCheck != null && EmailCheck != null)
                    {
                        await DisplayAlert("Alert", "Username and Email already exist", "OK");
                    }
                    else if (UserCheck != null)
                    {
                        await DisplayAlert("Alert", "Username already exist", "OK");
                    }
                    else if (EmailCheck != null)
                    {
                        await DisplayAlert("Alert", "Email already exist", "OK");
                    }
                }
            });
        }

        async void btnPickImage_Clicked(object sender, EventArgs e)
        {
            var pickResult = await FilePicker.PickMultipleAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick image(s)"
            });

            if (pickResult != null)
            {
                int cnt = 0;
                // สร้างตัวแปรชื่อ image เข้าไปวนใน pickResult คั้งแต่ 1..n
                foreach (var image in pickResult)
                {
                    cnt++;
                    var stream = await image.OpenReadAsync();
                    byte[] _imageByte = SteamToByteArray(stream);
                    _viewModel.ImageList.Add(new FileImages
                    {
                        FileName = image.FileName,
                        FileURL = "-",
                        Image = ImageSource.FromStream(() =>
                        new MemoryStream(_imageByte))
                    });
                }
            }
        }
        private byte[] SteamToByteArray(System.IO.Stream pSource)
        {
            byte[] imageAsBytes;
            using (var memoryStream = new MemoryStream())
            {
                pSource.CopyTo(memoryStream);
                imageAsBytes = memoryStream.ToArray();
            }
            return imageAsBytes;
        }
    }
}