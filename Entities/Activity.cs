using System.ComponentModel.DataAnnotations;

namespace MVC_grade_app.Entities
{
    public class Activity
    {
        [Key]
        public Guid Id { get; set; }
        public required string? Title { get; set; }
        public required decimal? Percentage { get; set; }
        public ActivityTypeEnum Type { get; set; }
    }
}
