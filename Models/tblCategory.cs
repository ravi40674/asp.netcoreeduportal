using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class tblCategory
    {
        [Key]
        public int CategoryID { get; set; }
        [Display(Name ="Category Name")]
        [Required(ErrorMessage = "Category Name is required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only.")]
        public string Name { get; set; }
        [Display(Name ="Is Active?")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
    }
}
