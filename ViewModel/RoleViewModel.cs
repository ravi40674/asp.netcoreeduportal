using EducationPortal.Common;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.ViewModel
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "RequiredField")]
        [StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MaxAllowedLength")]
        public string Role { get; set; }
        [StringLength(255, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MaxAllowedLength")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Active { get; set; }
        public bool IsAdminRole { get; set; }
        public string AdminRole { get; set; }
        public CommonMessagesViewModel ModuleName { get; set; }
    }
}
