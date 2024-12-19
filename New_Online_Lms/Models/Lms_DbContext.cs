using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace New_Online_Lms.Models
{
    public class Lms_DbContext : DbContext
    {
        public DbSet<User> Users { get; set; }           
        public DbSet<Course> Courses { get; set; }      
        public DbSet<Enrollment> Enrollments { get; set; } 
        public DbSet<Assignment> Assignments { get; set; } 
        public DbSet<Submission> Submissions { get; set; } 
        public DbSet<Progress> Progresses { get; set; }  

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---------------------- Course and User (Instructor) ----------------------

            // Define the relationship between Course and User (Instructor)
            modelBuilder.Entity<Course>()
                .HasOptional(c => c.Instructor) // A Course can optionally have an Instructor
                .WithMany() // Skip ICollection<Course> in the User model
                .HasForeignKey(c => c.InstructorId) // InstructorId is the foreign key in Course
                .WillCascadeOnDelete(false); // Prevent cascading delete; InstructorId will be null when User is deleted

            // ---------------------- Enrollment and User (Student) ----------------------

            // Define the relationship between Enrollment and User (Student)
            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Student) // An Enrollment must have a Student
                .WithMany() // Skip ICollection<Enrollment> in User model
                .HasForeignKey(e => e.StudentId) // StudentId is the foreign key in Enrollment
                .WillCascadeOnDelete(true); //  Enrollment gets deleted if User is deleted

            // ---------------------- Enrollment and Course ----------------------

            // Define the relationship between Enrollment and Course
            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Course) // An Enrollment must be linked to a Course
                .WithMany() // Skip ICollection<Enrollment> in Course model
                .HasForeignKey(e => e.CourseId) // CourseId is the foreign key in Enrollment
                .WillCascadeOnDelete(true); // Enrollment get deleted if Course is deleted

            // ---------------------- Assignment and Course ----------------------

            // Define the relationship between Assignment and Course
            modelBuilder.Entity<Assignment>()
                .HasRequired(a => a.Course) // An Assignment must belong to a Course
                .WithMany() // Skip ICollection<Assignment> in Course model
                .HasForeignKey(a => a.CourseId) // CourseId is the foreign key in Assignment
                .WillCascadeOnDelete(true); // Assignment gets deleted if Course is deleted

            // ---------------------- Submission and Assignment ----------------------

            // Define the relationship between Submission and Assignment
            modelBuilder.Entity<Submission>()
                .HasRequired(s => s.Assignment) // A Submission must be linked to an Assignment
                .WithMany() // Skip ICollection<Submission> in Assignment model
                .HasForeignKey(s => s.AssignmentId) // AssignmentId is the foreign key in Submission
                .WillCascadeOnDelete(true); //  Submission gets deleted if Assignment is deleted

            // ---------------------- Submission and User (Student) ----------------------

            // Define the relationship between Submission and User (Student)
            modelBuilder.Entity<Submission>()
                .HasRequired(s => s.Student) // A Submission must be linked to a Student
                .WithMany() // Skip ICollection<Submission> in User model
                .HasForeignKey(s => s.StudentId) // StudentId is the foreign key in Submission
                .WillCascadeOnDelete(true); //  Submission gets deleted if Student is deleted

            // ---------------------- Progress and User (Student) ----------------------

            // Define the relationship between Progress and User (Student)
            modelBuilder.Entity<Progress>()
                .HasRequired(p => p.Student) // Progress must be linked to a Student
                .WithMany() // Skip ICollection<Progress> in User model
                .HasForeignKey(p => p.StudentId) // StudentId is the foreign key in Progress
                .WillCascadeOnDelete(true); //  Progress gets deleted  if Student is deleted

            // ---------------------- Progress and Assignment ----------------------

            // Define the relationship between Progress and Assignment
            modelBuilder.Entity<Progress>()
                .HasRequired(p => p.Assignment) // Progress must be linked to an Assignment
                .WithMany() // Skip ICollection<Progress> in Assignment model
                .HasForeignKey(p => p.AssignmentId) // AssignmentId is the foreign key in Progress
                .WillCascadeOnDelete(true); // Progress gets deleted if Assignment is deleted
        }
    }
}