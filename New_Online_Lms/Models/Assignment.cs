using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New_Online_Lms.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; } 

        
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

       
        public Course Course { get; set; }
    }
}