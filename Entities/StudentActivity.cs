using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_grade_app.Entities
{
    public class StudentActivity
    {
        [Key]
        public Guid Id { get; set; }
        public TermEnum Term { get; set; }
        [ForeignKey(nameof(ActivityId))]
        public Guid ActivityId { get; set; }

        public Activity? Activity { get; set; }
    }
}