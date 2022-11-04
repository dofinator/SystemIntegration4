﻿using System.ComponentModel.DataAnnotations;

namespace schoolAPI.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<StudentStudyProgramme> StudentStudyProgramme { get; set; }
    }
}
