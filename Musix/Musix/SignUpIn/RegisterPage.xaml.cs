using Firebase.Auth;
using Musix.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Musix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Go_Back(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }

        async void PickupPicture(object sender, EventArgs e)
        {
           
        }
        async void SignUp(System.Object sender, System.EventArgs e)
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
      
        }
    }
}