using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public partial class Userschk
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
