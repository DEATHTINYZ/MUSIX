using Musix.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Musix
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public IList<Music> Mlist { get; set; }
        public SearchPage()
        {
            InitializeComponent();
            Mlist = new List<Music>();
            Mlist.Add(new Music { Title = "Feels Like You", Artist = "Faime", Url = "" });
            Mlist.Add(new Music { Title = "I Love You 3000", Artist = "Stephanie Poetri", Url = "" });
            Mlist.Add(new Music { Title = "Changes", Artist = "Jeff Bernat", Url = "" });
            Mlist.Add(new Music { Title = "วันอากาศดีๆ ที่ไม่มีเธออยู่", Artist = "AUTTA", Url = "" });
            Mlist.Add(new Music { Title = "I'm Yours", Artist = "Jason Mraz", Url = "" });
            BindingContext = this;
        }

        private void Search_Text(object sender, TextChangedEventArgs e)
        {
            var searchresult = Mlist.Where(c => c.Title.Contains(Search.Text));
            col.ItemsSource = searchresult;
        }
    }
}