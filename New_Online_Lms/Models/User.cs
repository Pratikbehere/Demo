using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New_Online_Lms.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } 

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; } 

        [Required]
        public string Role { get; set; }

        
    }
}