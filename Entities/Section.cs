using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_grade_app.Entities
{
    public class Section
    {
        [Key]
        public Guid Id { get; set; }
        public required string? Name { get; set; }


        [ForeignKey(nameof(CourseId))]
        public Guid CourseId { get; set; }
        public Course? Course { get; set; }        
    }

    public class SubjectEnrolment
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(SectionId))]
        public Guid SectionId { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public Guid SubjectId { get; set; }

    }
}
