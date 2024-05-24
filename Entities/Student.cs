using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVC_grade_app.Entities
{
    public class Student
    {
        [Key]
        public required Guid Id { get; set; }
        public required string? StudentNumber { get; set; }
        public required string? FirstName { get; set; }
        public required string? LastName { get; set;}
        public string? MiddleName { get; set; }
        public required string? Email { get; set; }
    }
}
