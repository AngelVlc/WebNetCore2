using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCore2.Models
{    
    public class Users
    {
        //[Key]
        public int userId { get; set; }

        public int googleId { get; set; }

        public string name { get; set; }
    }
}
