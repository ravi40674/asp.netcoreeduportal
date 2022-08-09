using EducationPortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.ViewModel
{
    public class CourseCollegeViewModel
    {
        [Key]
        public int CollegeCourseId { get; set; }
        [Display(Name = "Course")]
        [Required(ErrorMessage = "Course is Required")]
        public List<tblCollegeCourse> CourseId { get; set; }
        public List<tblCourse> CourseName { get; set; }
        public int CollegeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
