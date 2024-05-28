using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_grade_app.Entities
{
    public class SubjectEnrolment
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(SectionId))]
        public Guid SectionId { get; set; }

        [ForeignKey(nameof(SubjectId))]
        public Guid SubjectId { get; set; }

        public Section? Section { get; set; }
        public Subject? Subject { get; set; }

    }
}
