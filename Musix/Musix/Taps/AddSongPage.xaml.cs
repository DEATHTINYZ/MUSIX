using Musix.Model;
using Musix.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Musix.Taps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSongPage : ContentPage
    {
        public AddSongPage()
        {
            InitializeComponent();
        }

        private void AddSong_Click(object sender, EventArgs e)
        {
            Music musics = ((AddSongViewModel)BindingContext).music;

            MessagingCenter.Send(this, "AddSong", musics);
            Navigation.PopAsync();
        }
    }
}