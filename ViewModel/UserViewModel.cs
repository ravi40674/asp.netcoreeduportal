using EducationPortal.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.ViewModel
{
    public class UserViewModel
    {
        [Key]
        public int UserID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "RequiredField")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use only Alphabets")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "RequiredField")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use only Alphabets")]
        public string LastName { get; set; }
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "RequiredField")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Use numbers only")]
        public string MobileNumber { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "RequiredField")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "InvalidEmail")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "RequiredField")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string? ConPassword { get; set; }
        [Display(Name = "Role")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "RequiredField")]
        public int RoleID { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "RequiredField")]
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ModuleName { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public SelectList SelectRole { get; set; }
        public string roleneme { get;set; }
    }
}
