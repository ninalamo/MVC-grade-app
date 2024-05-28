using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_grade_app.Entities
{
    public class StudentGrade
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
        public ICollection<StudentActivity> StudentActivities { get; set; } = [];

    }
}