using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Musix.Model;
using Musix.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Musix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class LoginPage : ContentPage
    {
        public static IDataStore<Profile> DataStore => DependencyService.Get<IDataStore<Profile>>();

        public LoginPage()
        {
            InitializeComponent();

        }


        private void RegisterPage(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegisterPage();

        }

        async void SignUp(object sender, EventArgs e)
        {
            var Users = await LoginPage.DataStore.GetItemAsync(UsernameAuth.Text);
            var Emails = await LoginPage.DataStore.GetItemAsyncEmail(UsernameAuth.Text);

            if(Users != null)
            {
                if(Users.Username == UsernameAuth.Text && Users.Password == PasswordLogin.Text)
                {
                    await DisplayAlert("MUSIX", "YOUR WELCOME TO HOME PAGE", "OK");
                    Application.Current.MainPage = new MainTab();
                }
                else
                {
                    await DisplayAlert("Wrong", "Login fail", "OK");
                }
            }
            else if (Emails != null)
            {
                if (Emails.Email == UsernameAuth.Text && Emails.Password == PasswordLogin.Text)
                {
                    await DisplayAlert("MUSIX", "YOUR WELCOME HOME PAGE", "OK");
                    Application.Current.MainPage = new MainTab();
                }
                else
                {
                    await DisplayAlert("Wrong", "Login fail", "OK");
                }
            }
            else
            {
                await DisplayAlert("Wrong", "Have no this user and email", "OK");
            }
        }
    }
}