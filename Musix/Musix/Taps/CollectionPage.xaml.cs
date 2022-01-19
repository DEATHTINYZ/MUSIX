using Musix.Model;
using Musix.ViewModel;
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
    public partial class CollectionPage : ContentPage
    {
        public CollectionPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;
            Music music = ((MusixViewModel)BindingContext).MusixList.Where(mu => mu.Id == (int)tappedEventArgs.Parameter).FirstOrDefault();

            ((MusixViewModel)BindingContext).MusixList.Remove(music);
        }
    }
}