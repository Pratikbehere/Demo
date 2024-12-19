using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace New_Online_Lms.Models
{
    public class Progress
    {
        [Key]
        public int ProgressId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int AssignmentId { get; set; }

        public bool IsComplete { get; set; }

        public DateTime? CompletionDate { get; set; } 

       
        [ForeignKey("StudentId")]
        public User Student { get; set; }

        [ForeignKey("AssignmentId")]
        public Assignment Assignment { get; set; }
    }
}