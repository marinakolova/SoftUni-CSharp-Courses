namespace P01_StudentSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        public int ResourceId { get; set; }
        
        [MaxLength(50)]
        public string Name { get; set; }
        
        public string Url { get; set; }

        public ResourceType ResourceType { get; set; }
        
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

    public enum ResourceType
    {
        Video = 1, 
        Presentation = 2, 
        Document = 3,
        Other = 4
    }
}
