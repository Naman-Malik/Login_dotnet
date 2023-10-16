using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
