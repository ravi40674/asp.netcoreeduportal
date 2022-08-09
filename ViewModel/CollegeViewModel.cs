using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace EducationPortal.ViewModel
{
    public class CollegeViewModel
    {
        [Key]
        public int CollegeId { get; set; }
        [Display(Name = "University Name")]
        [Required(ErrorMessage = "University Name is Required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only.")]
        public string Name { get; set; }
        [Display(Name ="Rating")]
        [Required(ErrorMessage ="Rating is Required")]
        [Range(1.0,5.0,ErrorMessage ="Enter number between 1.0 to 5.0")]
        public float Rating { get; set; }
        [Display(Name ="Rating Type")]
        [Required(ErrorMessage ="Rating Type is Required")]
        [RegularExpression(@"^[a-zA-Z +-,]+$", ErrorMessage = "Use letters only.")]
        public string RatingType { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        [Display(Name ="University Logo ( .jpg | .jpeg | .png )")]
        public IFormFile Logo { get; set; }
        public string imgurl { get; set; }
        [Display(Name ="Is Active?")]
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public Nullable<DateTime> UpdatedDate { get; set; }
        [Display(Name ="Students Enrolled")]
        [Required(ErrorMessage = "Students Enrolled is Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Use only numeric.")]
        public string StudentsEnrolled { get; set; }
        [Display(Name = "Students Rating")]
        [Required(ErrorMessage = "Students Rating is Required")]
        [Range(1.0, 5.0, ErrorMessage = "Enter number between 1.0 to 5.0")]
        public float StudentsRating { get; set; }
        [Required(ErrorMessage = "Approvals is Required")]
        public string Approvals { get; set; }
        [Required(ErrorMessage = "Pros is Required")]
        public string Pros { get; set; }
        [Required(ErrorMessage = "Cons is Required")]
        public string Cons { get; set; }
        public string imgurl2 { get; set; }
        [Display(Name = "Education Mode")]
        [Required(ErrorMessage = "Education Mode is Required")]
        public string EducationMode { get; set; }
        [Display(Name = "Placement Assistance(%)")]
        [Required(ErrorMessage = "Placement Assistance is Required")]
        [Range(1.00, 100.00, ErrorMessage = "Enter number between 1.00 to 100.00")]
        public float PlacementAssistance { get; set; }
        [Required(ErrorMessage = "Eligibility is Required")]
        public string Eligibility { get; set; }
        [Display(Name = "College Score")]
        [Required(ErrorMessage = "College Score is Required")]
        [Range(1.00, 10.00, ErrorMessage = "Enter number between 1.00 to 10.00")]
        public float Collegescore { get; set; }
        [Display(Name = "NAAC Score")]
        [Required(ErrorMessage = "NAAC Score is Required")]
        [Range(1.00, 4.00, ErrorMessage = "Enter number between 1.00 to 4.00")]
        public float NaacScore { get; set; }
        [Display(Name = "NIRF Rank")]
        [Required(ErrorMessage = "NIRF Rank is Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Use only numeric.")]
        public string NirfRank { get; set; }
        [Display(Name = "E-Learning")]
        [Required(ErrorMessage = "E-Learning is Required")]
        public string ELearnings { get; set; }
        [Display(Name = "Online Classes")]
        [Required(ErrorMessage = "Online Classes is Required")]
        public string OnlineClasses { get; set; }
        [Display(Name = "Satisfied Students(%)")]
        [Required(ErrorMessage = "Satisfied Students is Required")]
        [Range(1.00, 100.00, ErrorMessage = "Enter number between 1.00 to 100.00")]
        public float SatisfiedStudents { get; set; }
        [Display(Name = "Industry Ready")]
        [Required(ErrorMessage = "Industry Ready is Required")]
        public string IndustryReady { get; set; }
        [Display(Name = "Sample Certificate ( .jpg | .jpeg | .png )")]
        public IFormFile SampleCertificate { get; set; }
        public string Emi { get; set; }
        [Display(Name = "Wes(International) Approval")]
        [Required(ErrorMessage = "Wes(International) is Required")]
        public string WesApproval { get; set; }
    }
}
