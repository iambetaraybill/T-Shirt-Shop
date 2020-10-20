using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TokenAuthClientMVC.Models
{
    public class User
    {
        [Key]
        public int UId { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
