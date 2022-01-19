using Musix.Model;
using Musix.Taps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Musix.ViewModel
{
    public class MusixViewModel
    {
        public ObservableCollection<Music> MusixList { get; set; }
        public MusixViewModel()
        {
            MusixList = new ObservableCollection<Music>();
            MusixList.Add(new Music() { Id = 1, Title = "Feels Like You", Artist = "Faime", Url = "" });
            MusixList.Add(new Music() { Id = 2, Title = "I Love You 3000", Artist = "Stephanie Poetri", Url = "" });
            MusixList.Add(new Music() { Id = 3, Title = "Changes", Artist = "Jeff Bernat", Url = "" });
            MusixList.Add(new Music() { Id = 4, Title = "วันอากาศดีๆ ที่ไม่มีเธออยู่", Artist = "AUTTA", Url = "" });
            MusixList.Add(new Music() { Id = 5, Title = "I'm Yours", Artist = "Jason Mraz", Url = "" });

            MessagingCenter.Subscribe<AddSongPage, Music>(this, "AddSong", (page, music) => {
                if (music.Id == 0)
                {
                    music.Id = MusixList.Count + 1;
                    MusixList.Add(music);
                }
            });
        }
    }
}
