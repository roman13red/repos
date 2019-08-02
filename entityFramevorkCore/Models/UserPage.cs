using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entityFramevorkCore.Models
{
    public class UserPage
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int PageId { get; set; }
        public Page Page{ get; set; }
    }
}
