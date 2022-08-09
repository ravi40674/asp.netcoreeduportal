using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class tblRolePrivilege
    {
        [Key]
        public int PrivilegeID { get; set; }
        public int MenuItemID { get; set; }
        public string MenuItem { get; set; }
        public string MenuItemController { get; set; }
        public string MenuItemView { get; set; }
        public bool View { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Detail { get; set; }
        public int ParentID { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public int? RoleId { get; set; }
    }
}