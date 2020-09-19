namespace P01_StudentSystem.Data.Models
{
    using System;

    public class Homework
    {
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public ContentType ContentType { get; set; }
        
        public DateTime SubmissionTime { get; set; }
        
        public int StudentId { get; set; }
        public Student Student { get; set; }
        
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

    public enum ContentType
    {
        Application = 1,
        Pdf = 2,
        Zip = 3
    }
}
