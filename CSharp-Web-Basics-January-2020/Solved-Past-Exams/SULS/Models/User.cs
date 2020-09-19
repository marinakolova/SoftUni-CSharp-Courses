using SIS.MvcFramework;
using System;
using System.Collections.Generic;

namespace SULS.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }

        public ICollection<Submission> Submissions { get; set; }
    }
}
