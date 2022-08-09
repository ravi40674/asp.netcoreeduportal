using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Models
{
    public class tblBlog
    {
        [Key]
        public int BlogID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        [Required(ErrorMessage ="Title is Required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        public string Keyword { get; set; }

        public string Image { get; set; }
        [NotMapped]
        public IFormFile imgurl { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
    }
}
