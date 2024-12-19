using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New_Online_Lms.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; } 

       
        [ForeignKey("Student")]
        public int StudentId { get; set; } 

        [ForeignKey("Course")]
        public int CourseId { get; set; } 

        public DateTime EnrollmentDate { get; set; }

       
        public User Student { get; set; }
        public Course Course { get; set; }
    }
}