using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Musix
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Loading();
        }

        public async Task Loading()
        {
            imgLogo.Opacity = 0;
            await imgLogo.FadeTo(1, 7000);
            Application.Current.MainPage = new LoginPage();
        }
    }
}
