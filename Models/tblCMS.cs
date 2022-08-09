using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class tblCMS
    {
        [Key]
        public int CMSId { get; set; }
        [Display(Name ="Page Name")]
        public string PageName { get; set; }
        [Display(Name = "Page Content")]
        public string PageContent { get; set; }
        [Display(Name = "Page Title")]
        public string Title { get; set; }
        [Display(Name = "Page Keyword")]
        public string Keyword { get; set; }
        [Display(Name = "Page Description")]
        public string Description { get; set; }
        [Display(Name ="Is Active?")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
