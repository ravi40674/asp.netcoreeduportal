using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Models
{
    public class tblDesignation
    {
        [Key]
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
    }
}
