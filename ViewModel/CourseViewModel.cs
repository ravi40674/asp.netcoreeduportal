using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.ViewModel
{
    public class CourseViewModel
    {
        public int CourseID { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is Required")]
        public Nullable<int> CategoryID { get; set; }
        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Course Name is Required")]
        [RegularExpression(@"^[a-zA-Z &-.]+$", ErrorMessage = "Use letters only.")]
        public string Name { get; set; }
        [Display(Name = "Display Name")]
        [Required(ErrorMessage = "Display Name is Required")]
        [RegularExpression(@"^[a-zA-Z &-.]+$", ErrorMessage = "Use letters only.")]
        public string DisplayName { get; set; }
        public int CreatedBy { get; set; }
        [Display(Name = "Parent")]
        public Nullable<int> ParentId { get; set; }
        public int ModifiedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "Course Image ( .jpg | .jpeg | .png )")]
        public IFormFile Image { get; set; }
        public string imgurl { get; set; }
    }
}
