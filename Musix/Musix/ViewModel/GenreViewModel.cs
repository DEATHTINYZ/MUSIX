using Musix.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musix.ViewModel
{
    class GenreViewModel
    {
        public IList<GenreListModel> GenreList { get; set; }

        public GenreViewModel()
        {
            GenreList = new List<GenreListModel>();
            GenreList.Add(new GenreListModel { NameGenre = "Instrumental" });
            GenreList.Add(new GenreListModel { NameGenre = "Classic" });
            GenreList.Add(new GenreListModel { NameGenre = "Jazz" });
            GenreList.Add(new GenreListModel { NameGenre = "POP" });
            GenreList.Add(new GenreListModel { NameGenre = "Rock" });
            GenreList.Add(new GenreListModel { NameGenre = "R&B" });
            GenreList.Add(new GenreListModel { NameGenre = "Hip hop" });
            GenreList.Add(new GenreListModel { NameGenre = "Rap" });
        }
    }
}
