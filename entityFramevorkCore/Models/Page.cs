using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entityFramevorkCore.Models
{
    public class Page
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public  List<UserPage> Users { get; set; }
        public Page()
        {
            Users = new List<UserPage>();
        }
    }
}
