using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.Models
{
    public class tblSuggest
    {
        [Key]
        public int SuggestID { get; set; }
        public int CourseID { get; set; }
        public int SpecializationID { get; set; }
        public int InquiryID { get; set; }
        public bool IsWorking { get; set; }
        public string Qualification { get; set; }
        public string Budget { get; set; }
        public string StudyHours { get; set; }
        public string FreeStructure { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
    }
}
