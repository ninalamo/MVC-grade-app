﻿using System.ComponentModel.DataAnnotations;
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
}
