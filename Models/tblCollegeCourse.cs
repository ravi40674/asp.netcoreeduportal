using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class tblCollegeCourse
    {
        [Key]
        public int CollegeCourseId { get; set; }
        [Display(Name ="Course")]
        [Required(ErrorMessage ="Course is Required")]
        public int CourseId { get; set; }
        public int CollegeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
