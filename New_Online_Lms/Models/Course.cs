using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New_Online_Lms.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; } 

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        
        [ForeignKey("Instructor")]
        public int? InstructorId { get; set; }

        
        public User Instructor { get; set; } 
    }
}