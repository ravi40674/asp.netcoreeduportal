using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class tblCollegeSemester
    {
        [Key]
        public int CollegeSemesterId { get; set; }
        public int CollegeId { get; set; }
        [Display(Name ="Course")]
        [Required(ErrorMessage = "Course is Required")]
        public int CourseId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        [Display(Name = "University Fee")]
        [Required(ErrorMessage = "University Fee is Required")]
        public float SemesterFee { get; set; }
        [Display(Name = "Other Notes")]
        public string OtherNotes { get; set; }
        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
