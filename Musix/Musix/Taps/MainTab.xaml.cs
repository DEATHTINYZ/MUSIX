using Musix.Taps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Musix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTab : Shell
    {
        public MainTab()
        {
            InitializeComponent();
            BindingContext = this;
            Routing.RegisterRoute("//LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("//EditProfile", typeof(EditProfile));
        }

        public ICommand ExecuteLogout => new Command(async () => await GoToAsync("//LoginPage"));
        public ICommand ExecuteEditProfile => new Command(async () => await GoToAsync("//EditProfile"));

/*        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();

        }*/
    }
}