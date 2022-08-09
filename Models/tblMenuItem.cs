using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class tblMenuItem
    {
        [Key]
        public int MenuItemID { get; set; }
        public string MenuItem { get; set; }
        public string MenuItemController { get; set; }
        public string MenuItemView { get; set; }
        public int SortOrder { get; set; }
        public int ParentID { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompanyAdminType { get; set; }
    }
}