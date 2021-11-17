using Musix.Service;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: ExportFont("mttregular.otf", Alias = "mttregular")]
[assembly: ExportFont("msregular.otf", Alias = "msregular")]
[assembly: ExportFont("moregular.otf", Alias = "moregular")]
[assembly: ExportFont("mrregular.otf", Alias = "mrregular")]

namespace Musix
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<IDataStore<Model.Profile>, FSDataStore>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
