using System.ComponentModel.DataAnnotations;

namespace MVC_grade_app.Entities
{
    public class Subject
    {
        [Key]
        public Guid Id { get; set; }
        public required string? Code { get; set;}
        public string? Description { get; set; }        
    }
}
