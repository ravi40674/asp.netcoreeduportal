using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Models
{
    public class tblNewsLetter
    {
        [Key]
        public int NewsLetterID { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool IsSubscribed { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
