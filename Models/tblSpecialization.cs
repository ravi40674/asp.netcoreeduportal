using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class tblSpecialization
    {
        [Key]
        public int SpecializationID { get; set; }
        [Display(Name ="Course")]
        [Required(ErrorMessage ="Course is Required")]
        public int CourseID { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [Display(Name ="Specification Name")]
        [Required(ErrorMessage = "Specification Name is Required")]
        [RegularExpression(@"^[a-zA-Z #&.-]+$", ErrorMessage = "Use letters only.")]
        public string Name { get; set; }
        [Display(Name ="Is Active?")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
    }
}
