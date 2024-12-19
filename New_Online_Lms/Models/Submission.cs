using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New_Online_Lms.Models
{
    public class Submission
    {
        [Key]
        public int SubmissionId { get; set; } 

        
        [ForeignKey("Assignment")]
        public int AssignmentId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; } 

        public string Grade { get; set; } 
        public DateTime SubmittedOn { get; set; }=DateTime.Now;

        
        public Assignment Assignment { get; set; }
        public User Student { get; set; }
    }
}