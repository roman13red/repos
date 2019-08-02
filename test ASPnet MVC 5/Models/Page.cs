using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test_ASPnet_MVC_5.Models
{
    public class Page
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public Page()
        {
            Users = new List<User>();
        }
    }
}