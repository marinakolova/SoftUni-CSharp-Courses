using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUniTwitter.Models
{
    public class TweetViewModel
    {
        public string Text { get; set; }

        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
