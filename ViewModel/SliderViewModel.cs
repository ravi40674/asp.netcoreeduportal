using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.ViewModel
{
    public class SliderViewModel
    {
        public int SliderID { get; set; }
        public string PageName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        [Display(Name = "Slider Image ( .jpg | .jpeg | .png )")]
        public IFormFile Image { get; set; }
        public string imgurl { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
    }
}
