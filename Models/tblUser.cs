using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class tblUser
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int RoleID { get; set; }
    }
}