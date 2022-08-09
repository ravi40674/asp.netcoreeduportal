using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Models
{
    public class tblTemplate
    {
        [Key]
        public int TemplateID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        [Required(ErrorMessage ="Subject is Required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public List<tblNewsLetter> tblNewsLetter { get; set; }
    }
}
