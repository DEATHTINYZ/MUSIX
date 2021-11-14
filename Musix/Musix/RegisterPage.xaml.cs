using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void PickupPicture(object sender, EventArgs e)
        {

        }

        private void SignUp(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}