using System;
using System.Collections.Generic;
using System.Text;

namespace Musix.Model
{
    public class Music
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Url { get; set; }
        public string CoverImage { get; set; } = "https://usercontent2.hubstatic.com/14548043_f1024.jpg";
        public bool IsRecent { get; set; }

    }
}
