using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class tblCourseInquiry
    {
        [Key]
        public int CourseInquiryId { get; set; }
        [Display(Name ="Age")]
        [Required(ErrorMessage ="Age is Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Use only numeric.")]
        public int Age { get; set; }
        [Display(Name ="Full Name")]
        [Required(ErrorMessage = "Full Name is Required")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }
        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Mobile is Required")]
        public string Mobile { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
