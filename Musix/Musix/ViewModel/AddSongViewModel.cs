using Musix.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musix.ViewModel
{
    public class AddSongViewModel
    {
        public Music music { get; set; }
        public AddSongViewModel()
        {
            music = new Music();
        }
    }
}
