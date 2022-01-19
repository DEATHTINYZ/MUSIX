using Musix.Model;
using Musix.Taps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Musix.ViewModel
{
    public class HomeViewModel : NewBaseViewModel
    {
        public HomeViewModel()
        {
            musicList = GetMusics();
            recentMusic = musicList.Where(x => x.IsRecent == true).FirstOrDefault();

        }
        ObservableCollection<Music> musicList;
        public ObservableCollection<Music> MusicList
        {
            get { return musicList; }
            set
            {
                musicList = value;
                OnPropertyChanged();
            }
        }

        private Music recentMusic;
        public Music RecentMusic
        {
            get { return recentMusic; }
            set
            {
                recentMusic = value;
                OnPropertyChanged();
            }
        }

        private Music selectedMusic;
        public Music SelectedMusic
        {
            get { return selectedMusic; }
            set
            {
                selectedMusic = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(PlayMusic);

        private void PlayMusic()
        {
            if (selectedMusic != null)
            {
                var viewModel = new PlaySongViewModel(selectedMusic, musicList);
                var playerPage = new PlaySongPage { BindingContext = viewModel };

                /*var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(playerPage, true);*/
                Application.Current.MainPage = new PlaySongPage { BindingContext = viewModel };
            }
        }
        private ObservableCollection<Music> GetMusics()
        {
            return new ObservableCollection<Music>
            {
                new Music { Title = "Feels Like You", Artist = "Faime", Url = ""},
                new Music { Title = "I Love You 3000", Artist = "Stephanie Poetri", Url = ""},
                new Music { Title = "Changes", Artist = "Jeff Bernat", Url = ""},
                new Music { Title = "วันอากาศดีๆ ที่ไม่มีเธออยู่", Artist = "AUTTA", Url = ""},
                new Music { Title = "I'm Yours", Artist = "Jason Mraz", Url = ""}
            };
        }
    }
}
