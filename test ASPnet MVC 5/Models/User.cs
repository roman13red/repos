using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_ASPnet_MVC_5.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string email { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public User()
        {
            Pages = new List<Page>();
        }

    }
}