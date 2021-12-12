using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Musix.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Musix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfile : ContentPage
    {
        public Profile getData;
        public EditProfile()
        {
            InitializeComponent();
            Profile getData = new Profile();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var data = await checkModel();
            Usernames.Text = data.Username;
            Emails.Text = data.Email;
            Passwords.Text = data.Password;
        }

        public async void EditsProfile(object sender, EventArgs e)
        {
            var data = await checkModel();
            Profile UpdateProfile = new Profile()
            {
                ID = data.ID,
                Username = Usernames.Text,
                Email = Emails.Text,
                Password = Passwords.Text
            };

            await DisplayAlert("MUSIX", "Update Complete", "OK");
            await LoginPage.DataStore.UpdateItemAsync(UpdateProfile);
            if (LoginPage.IsEmails) LoginPage.SetUsername = Emails.Text;
            else LoginPage.SetUsername = Usernames.Text;
        }

        public async Task<Profile> checkModel()
        {
            if (LoginPage.IsEmails)
            {
                getData = await LoginPage.DataStore.GetItemAsyncEmail(LoginPage.SetUsername);
            }
            else
            {
                getData = await LoginPage.DataStore.GetItemAsync(LoginPage.SetUsername);
            }

            return getData;
        }
    }
}