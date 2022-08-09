using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class tblRole
    {
        [Key]
        public int RoleId { get; set; }
        [Display(Name ="Role Name")]
        [Required(ErrorMessage ="Role Name is Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only.")]
        public string RoleName { get; set; }
        [Display(Name ="Is Active?")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
    }
}