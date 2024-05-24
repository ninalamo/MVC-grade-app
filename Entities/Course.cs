using System.ComponentModel.DataAnnotations;

namespace MVC_grade_app.Entities
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
