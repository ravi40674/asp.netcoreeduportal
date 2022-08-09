using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Models
{
    public class tblEmailSendHistory
    {
        [Key]
        public int EmailSendHistoryID { get; set; }
        [Display(Name ="Template")]
        [Required(ErrorMessage = "Template is Required")]
        public string TemplateID { get; set; }
        [NotMapped]
        public List<tblNewsLetter> NewsLetterList { get; set; }
        public bool IsEmailSend { get; set; }
    }
}
