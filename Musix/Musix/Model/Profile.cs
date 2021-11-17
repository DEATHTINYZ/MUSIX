using System;
using System.Collections.Generic;
using System.Text;

namespace Musix.Model
{
    public class Profile
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<string> ImageFiles { get; set; }
    }
}
