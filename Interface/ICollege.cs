using EducationPortal.Models;
using EducationPortal.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Interface
{
    public interface ICollege
    {
        CollegeViewModel GetCourseDetailByCollegeID(int userID,string img);
        bool IsUpdateCollegeExists(string name, int collegeId);
        bool IsCollegeExists(string name);
        string Uploadimage(CollegeViewModel model);
        IQueryable<CollegeViewModel> CollegeListBind();
        void DeleteCollege(string[] collegeId);
        CollegeViewModel GetCollegeDetailByCollegeID(int userID);
        List<tblCollegeCourse> CollegeCoursegetById(string id);
        IQueryable<tblCMS> BindCMS();
        tblCMS GetCMSDetailByUserID(int cmsID);
        bool IsCMsExists(string pageName);
        void AddCMS(tblCMS objtbl);
        bool IsUpdateCMSExists(int cMSId, string pageName);
        void EditCMS(tblCMS objtbl);
        void DeleteCMS(string[] cMSID);
        IQueryable<tblSuggest> BindSuggest();
        IQueryable<tblCourseInquiry> BindCourseInquiry();
        string Uploadimage1(CollegeViewModel model);
        string UploadCourseimage(CourseViewModel model);
        IQueryable<tblSpecialization> BindSpecializationDetail();
        List<tblCourse> CourseBind();
        tblSpecialization GetSpecializationDetailByID(int userID);
        bool IsSpecializationUpdateExists(string name, int specializationID,int courseid);
        bool IsSpecializationExists(string name,int courseid);
        void DeleteSpecialization(string[] specializationID);
        tblBlog GetBlogDetailByUserID(int cmsID);
        void AddBlog(tblBlog objtbl);
        bool IsUpdateBlogExists(int blogID, string title);
        void EditBlog(tblBlog objtbl);
        IQueryable<tblBlog> BindBlog();
        bool IsUBlogExists(string title);
        void DeleteBlog(string[] blogID);
        string UploadBlogimage(tblBlog objtbl);
        IQueryable<tblTemplate> BindTemplate();
        void DeleteTemplate(string[] TemplateID);
        void AddTemplate(tblTemplate objtbl);
        void EditTemplate(tblTemplate objtbl);
        tblTemplate GetTemplateDetailByUserID(int templateID);
        bool IsExistTemplate(string name);
        tblRecipient GetRecipientDetailByUserID(int cmsID);
        bool IsExistUpdateTemplate(string name, int templateID);
        IQueryable<tblRecipient> BindRecipient();
        void AddEmailSend(tblEmailSendHistory objtbl);
        void EditRecipient(tblRecipient objtbl);
        void AddRecipient(tblRecipient objtbl);
        void DeleteRecipient(string[] recipientID);
        bool IsExistRecipient(string email);
        bool IsExistUpdateRecipient(string email, int recipientID);
        IQueryable<tblEmailSendHistory> BindEmailSend();
        void DeleteEmailSend(string[] emailSendHistoryID);
    }
}
