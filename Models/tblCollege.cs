using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class tblCollege
    {
        [Key]
        public int CollegeId { get; set; }
        public string StudentsEnrolled { get; set; }
        public float StudentsRating { get; set; }
        public string Approvals { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public string EducationMode { get; set; }
        public float PlacementAssistance { get; set; }
        public string Eligibility { get; set; }
        public float Collegescore { get; set; }
        public float NaacScore { get; set; }
        public string NirfRank { get; set; }
        public string ELearnings { get; set; }
        public string OnlineClasses { get; set; }
        public float SatisfiedStudents { get; set; }
        public string IndustryReady { get; set; }
        public string SampleCertificate { get; set; }
        public string Emi { get; set; }
        public string WesApproval { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public string RatingType { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string Logo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
    }
}
