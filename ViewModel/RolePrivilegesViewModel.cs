using EducationPortal.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.ViewModel
{
    public class RolePrivilegesViewModel
    {
        public int RolePrivilegeID { get; set; }

        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Role")]
        public int RoleId { get; set; }
        public SelectList Roles { get; set; }
        public SelectList MenuItemID { get; set; }
        public string ModuleName { get; set; }
    }
}
