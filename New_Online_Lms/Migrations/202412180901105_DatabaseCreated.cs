namespace New_Online_Lms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        DueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        InstructorId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Users", t => t.InstructorId)
                .Index(t => t.InstructorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Progresses",
                c => new
                    {
                        ProgressId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                        CompletionDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProgressId)
                .ForeignKey("dbo.Assignments", t => t.AssignmentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.AssignmentId);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        SubmissionId = c.Int(nullable: false, identity: true),
                        AssignmentId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Grade = c.String(),
                        SubmittedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubmissionId)
                .ForeignKey("dbo.Assignments", t => t.AssignmentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.AssignmentId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "StudentId", "dbo.Users");
            DropForeignKey("dbo.Submissions", "AssignmentId", "dbo.Assignments");
            DropForeignKey("dbo.Progresses", "StudentId", "dbo.Users");
            DropForeignKey("dbo.Progresses", "AssignmentId", "dbo.Assignments");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Users");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Assignments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "InstructorId", "dbo.Users");
            DropIndex("dbo.Submissions", new[] { "StudentId" });
            DropIndex("dbo.Submissions", new[] { "AssignmentId" });
            DropIndex("dbo.Progresses", new[] { "AssignmentId" });
            DropIndex("dbo.Progresses", new[] { "StudentId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Courses", new[] { "InstructorId" });
            DropIndex("dbo.Assignments", new[] { "CourseId" });
            DropTable("dbo.Submissions");
            DropTable("dbo.Progresses");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Users");
            DropTable("dbo.Courses");
            DropTable("dbo.Assignments");
        }
    }
}
