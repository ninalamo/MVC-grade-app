using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_grade_app.Entities
{
    public class GradeSheet
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(SectionId))]
        public Guid SectionId { get; set; }
        public string? Title { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime ModifiedDateTime { get; set; } = DateTime.Now;

        public Section? Section { get; set; }
        public ICollection<StudentGrade> StudentGrades { get; set; } = [];
    }
}
