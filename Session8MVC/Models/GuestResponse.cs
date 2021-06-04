using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Session8MVC.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please Enter Your Name.")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? WillAttend { get; set; }
    }
}
