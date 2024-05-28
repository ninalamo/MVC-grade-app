using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_grade_app.Entities;

namespace MVC_grade_app.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<MVC_grade_app.Entities.SubjectEnrolment> SubjectEnrolment { get; set; } = default!;
    }
}
