using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace entityFramevorkCore.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

      
        public string Phone { get; set; }

        public  List<UserPage> Pages { get; set; }
        public User()
        {
            Pages = new List<UserPage>();
        }

    }
}
