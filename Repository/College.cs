using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using EducationPortal.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EducationPortal.Repository
{
    public class College : ICollege
    {
        private static EducationPortalDBContext _context;
        public readonly IWebHostEnvironment _IWebHostEnvironment;
        public College(EducationPortalDBContext context, IWebHostEnvironment IWebHostEnvironment)
        {
            _context = context;
            _IWebHostEnvironment = IWebHostEnvironment;
        }

        public void AddBlog(tblBlog objtbl)
        {
            _context.tblBlog.Add(objtbl);
            _context.SaveChanges();
        }

        public void AddCMS(tblCMS objtbl)
        {
            _context.tblCMS.Add(objtbl);
            _context.SaveChanges();
        }

        public void AddEmailSend(tblEmailSendHistory objtbl)
        {
            _context.tblEmailSendHistory.Add(objtbl);
            _context.SaveChanges();
        }

        public void AddRecipient(tblRecipient objtbl)
        {
            _context.tblRecipient.Add(objtbl);
            _context.SaveChanges();
        }

        public void AddTemplate(tblTemplate objtbl)
        {
            _context.tblTemplate.Add(objtbl);
            _context.SaveChanges();
        }

        public IQueryable<tblBlog> BindBlog()
        {
            return _context.tblBlog;
        }

        public IQueryable<tblCMS> BindCMS()
        {
            return _context.tblCMS;
        }

        public IQueryable<tblCourseInquiry> BindCourseInquiry()
        {
            return _context.tblCourseInquiry;
        }

        public IQueryable<tblEmailSendHistory> BindEmailSend()
        {
            List<tblNewsLetter> list= _context.tblNewsLetter.Where(x => x.IsSubscribed && !x.IsDeleted).ToList();
            return from i in _context.tblEmailSendHistory
                   join o in _context.tblTemplate on i.TemplateID equals o.TemplateID.ToString()
                   where i.IsEmailSend
                   select new tblEmailSendHistory
                   {
                       TemplateID = o.Name,
                       IsEmailSend = i.IsEmailSend,
                       EmailSendHistoryID = i.EmailSendHistoryID,
                       NewsLetterList = list
                   };
        }

        public IQueryable<tblRecipient> BindRecipient()
        {
            return _context.tblRecipient;
        }

        public IQueryable<tblSpecialization> BindSpecializationDetail()
        {
            return _context.tblSpecialization;
        }

        public IQueryable<tblSuggest> BindSuggest()
        {
            return _context.tblSuggest;
        }

        public IQueryable<tblTemplate> BindTemplate()
        {
            return _context.tblTemplate;
        }

        public List<tblCollegeCourse> CollegeCoursegetById(string id)
        {
            var collegecourseList = _context.tblCollegeCourse.Where(x => x.CollegeId == Convert.ToInt32(id)&&x.IsActive&&!x.IsDeleted).AsNoTracking().ToList();
            return collegecourseList;
        }

        public IQueryable<CollegeViewModel> CollegeListBind()
        {
            var list = from i in _context.tblCollege
                       select new CollegeViewModel
                       {
                           CollegeId = i.CollegeId,
                           IsActive = i.IsActive,
                           IsDeleted = i.IsDeleted,
                           CreatedBy = i.CreatedBy,
                           CreatedDate = i.CreatedDate,
                           imgurl = i.Logo,
                           Name = i.Name,
                           Rating = i.Rating,
                           RatingType = i.RatingType,
                           UpdatedBy = i.UpdatedBy,
                           UpdatedDate = i.UpdatedDate,
                           imgurl2 = i.SampleCertificate,
                           IndustryReady = i.IndustryReady,
                           Approvals = i.Approvals,
                           Collegescore = i.Collegescore,
                           Cons = i.Cons,
                           EducationMode = i.EducationMode,
                           ELearnings = i.ELearnings,
                           Eligibility = i.Eligibility,
                           Emi = i.Emi,
                           NaacScore = i.NaacScore,
                           NirfRank = i.NirfRank,
                           OnlineClasses = i.OnlineClasses,
                           PlacementAssistance = i.PlacementAssistance,
                           Pros = i.Pros,
                           SatisfiedStudents = i.SatisfiedStudents,
                           StudentsEnrolled = i.StudentsEnrolled,
                           StudentsRating = i.StudentsRating,
                           WesApproval = i.WesApproval
                       };
            return list;
        }

        public List<tblCourse> CourseBind()
        {
            return _context.tblCourse.Where(x => x.IsActive && !x.IsDeleted).ToList();
        }

        public void DeleteBlog(string[] blogID)
        {
            for (int i = 0; i < blogID.Length; i++)
            {
                var record = _context.tblBlog.Where(x => x.BlogID == Convert.ToInt32(blogID[i])).FirstOrDefault();
                record.IsDeleted = true;
                var imgpath = Path.Combine(_IWebHostEnvironment.WebRootPath, "ApplicationDocument/BlogImages", record.Image);
                if (System.IO.File.Exists(imgpath))
                {
                    System.IO.File.Delete(imgpath);
                }
                _context.Entry(record).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeleteCMS(string[] cMSID)
        {
            for (int i = 0; i < cMSID.Length; i++)
            {
                var record = _context.tblCMS.Where(x => x.CMSId == Convert.ToInt32(cMSID[i])).FirstOrDefault();
                record.IsDeleted = true;
                _context.Entry(record).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeleteCollege(string[] collegeId)
        {
            for (int i = 0; i < collegeId.Length; i++)
            {
                var record = _context.tblCollege.Where(x => x.CollegeId == Convert.ToInt32(collegeId[i])).FirstOrDefault();
                record.IsDeleted = true;
                var imgpath = Path.Combine(_IWebHostEnvironment.WebRootPath, "ApplicationDocument/UniversityImages", record.Logo);
                if (System.IO.File.Exists(imgpath))
                {
                    System.IO.File.Delete(imgpath);
                }

                var imgpath2 = Path.Combine(_IWebHostEnvironment.WebRootPath, "ApplicationDocument/SampleCertificate", record.SampleCertificate);
                if (System.IO.File.Exists(imgpath2))
                {
                    System.IO.File.Delete(imgpath2);
                }
                _context.Entry(record).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeleteEmailSend(string[] emailSendHistoryID)
        {
            for (int i = 0; i < emailSendHistoryID.Length; i++)
            {
                var record = _context.tblEmailSendHistory.Where(x => x.EmailSendHistoryID == Convert.ToInt32(emailSendHistoryID[i])).FirstOrDefault();
                record.IsEmailSend = false;
                _context.Entry(record).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeleteRecipient(string[] recipientID)
        {
            for (int i = 0; i < recipientID.Length; i++)
            {
                var record = _context.tblRecipient.Where(x => x.RecipientID == Convert.ToInt32(recipientID[i])).FirstOrDefault();
                record.IsDeleted = true;
                _context.Entry(record).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeleteSpecialization(string[] specializationID)
        {
            for (int i = 0; i < specializationID.Length; i++)
            {
                var record = _context.tblSpecialization.Where(x => x.SpecializationID == Convert.ToInt32(specializationID[i])).FirstOrDefault();
                record.IsDeleted = true;
                _context.Entry(record).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeleteTemplate(string[] TemplateID)
        {
            for (int i = 0; i < TemplateID.Length; i++)
            {
                var record = _context.tblTemplate.Where(x => x.TemplateID == Convert.ToInt32(TemplateID[i])).FirstOrDefault();
                record.IsDeleted = true;
                _context.Entry(record).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void EditBlog(tblBlog objtbl)
        {
            _context.tblBlog.Update(objtbl);
            _context.SaveChanges();
        }

        public void EditCMS(tblCMS objtbl)
        {
            _context.Entry(objtbl).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EditRecipient(tblRecipient objtbl)
        {
            _context.tblRecipient.Update(objtbl);
            _context.SaveChanges();
        }

        public void EditTemplate(tblTemplate objtbl)
        {
            _context.tblTemplate.Update(objtbl);
            _context.SaveChanges();
        }

        public tblBlog GetBlogDetailByUserID(int blogID)
        {
            return _context.tblBlog.Where(x => x.BlogID == blogID).AsNoTracking().FirstOrDefault();
        }

        public tblCMS GetCMSDetailByUserID(int cmsID)
        {
            return _context.tblCMS.Where(x => x.CMSId == cmsID).AsNoTracking().FirstOrDefault();
        }

        public CollegeViewModel GetCollegeDetailByCollegeID(int userID)
        {
            var record = (from i in _context.tblCollege
                          where i.CollegeId == userID
                          select new CollegeViewModel
                          {
                              imgurl = i.Logo,
                              IsActive = i.IsActive,
                              IsDeleted = i.IsDeleted,
                              CollegeId = i.CollegeId,
                              CreatedBy = i.CreatedBy,
                              CreatedDate = i.CreatedDate,
                              Name = i.Name,
                              Rating = i.Rating,
                              RatingType = i.RatingType,
                              UpdatedBy = i.UpdatedBy,
                              UpdatedDate = i.UpdatedDate,
                              Approvals=i.Approvals,
                              OnlineClasses=i.OnlineClasses,
                              imgurl2=i.SampleCertificate,
                              IndustryReady=i.IndustryReady,
                              Collegescore = i.Collegescore,
                              Cons=i.Cons,
                              EducationMode=i.EducationMode,
                              ELearnings=i.ELearnings,
                              Eligibility=i.Eligibility,
                              Emi=i.Emi,
                              NaacScore=i.NaacScore,
                              NirfRank=i.NirfRank,
                              PlacementAssistance=i.PlacementAssistance,
                              Pros=i.Pros,
                              SatisfiedStudents=i.SatisfiedStudents,
                              StudentsEnrolled=i.StudentsEnrolled,
                              StudentsRating=i.StudentsRating,
                              WesApproval=i.WesApproval
                          }).FirstOrDefault();
            return record;
        }

        public CollegeViewModel GetCourseDetailByCollegeID(int userID,string img)
        {
            var record = (from i in _context.tblCollege
                          where i.CollegeId == userID
                          select new CollegeViewModel { 
                          imgurl=i.Logo,
                          imgurl2=i.SampleCertificate,
                          IsActive=i.IsActive,
                          IsDeleted=i.IsDeleted,
                          CollegeId=i.CollegeId,
                          CreatedBy=i.CreatedBy,
                          CreatedDate=i.CreatedDate,
                          Name=i.Name,
                          Rating=i.Rating,
                          RatingType=i.RatingType,
                          UpdatedBy=i.UpdatedBy,
                          UpdatedDate=i.UpdatedDate
                          }).FirstOrDefault();
            return record;
        }

        public tblRecipient GetRecipientDetailByUserID(int cmsID)
        {
            return _context.tblRecipient.Where(x => x.RecipientID == cmsID).AsNoTracking().FirstOrDefault();
        }

        public tblSpecialization GetSpecializationDetailByID(int userID)
        {
            return _context.tblSpecialization.Where(x => x.SpecializationID == userID).FirstOrDefault();
        }

        public tblTemplate GetTemplateDetailByUserID(int templateID)
        {
            return _context.tblTemplate.Where(x => x.TemplateID == templateID).AsNoTracking().FirstOrDefault();
        }

        public bool IsCMsExists(string pageName)
        {
            var cmsRecord = _context.tblCMS.Where(x => x.PageName == pageName&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            if (cmsRecord==null)
            {
                return false;
            }
            return true;
        }

        public bool IsCollegeExists(string name)
        {
            var collegerecord = _context.tblCollege.Where(x => x.Name == name &&x.IsActive &&!x.IsDeleted).SingleOrDefault();
            if (collegerecord==null)
            {
                return false;
            }
            return true;
        }

        public bool IsExistRecipient(string email)
        {
            var record = _context.tblRecipient.Where(x => x.Email == email&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            if (record==null)
            {
                return false;
            }
            return true;
        }

        public bool IsExistTemplate(string name)
        {
            var record = _context.tblTemplate.Where(x => x.Name == name && x.IsActive && !x.IsDeleted).SingleOrDefault();
            if (record==null)
            {
                return false;
            }
            return true;
        }

        public bool IsExistUpdateRecipient(string email, int recipientID)
        {
            var record = _context.tblRecipient.Where(x => x.Email == email && x.RecipientID != recipientID && x.IsActive && !x.IsDeleted).SingleOrDefault();
            if (record==null)
            {
                return false;
            }
            return true;
        }

        public bool IsExistUpdateTemplate(string name, int templateID)
        {
            var record = _context.tblTemplate.Where(x => x.Name == name && x.TemplateID != templateID && x.IsActive && !x.IsDeleted).SingleOrDefault();
            if (record==null)
            {
                return false;
            }
            return true;
        }

        public bool IsSpecializationExists(string name,int courseid)
        {
            var specializatinRecord = _context.tblSpecialization.Where(x => x.Name == name&&x.CourseID==courseid&&!x.IsDeleted).SingleOrDefault();
            var specializatinnameRecord = _context.tblSpecialization.Where(x => x.Name == name&&!x.IsDeleted).SingleOrDefault();
            if (specializatinRecord==null&& specializatinnameRecord==null)
            {
                return false;
            }
            return true;
        }

        public bool IsSpecializationUpdateExists(string name, int specializationID,int courseid)
        {
            var updateRecord = _context.tblSpecialization.Where(x => x.Name == name&&x.CourseID==courseid && x.SpecializationID != specializationID&&!x.IsDeleted).SingleOrDefault();
            var updatenameRecord = _context.tblSpecialization.Where(x => x.Name == name && x.SpecializationID != specializationID&&!x.IsDeleted).SingleOrDefault();
            if (updateRecord==null&& updatenameRecord==null)
            {
                return false;
            }
            return true;
        }

        public bool IsUBlogExists(string title)
        {
            var record = _context.tblBlog.Where(x => x.Title == title&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            if (record==null)
            {
                return false;
            }
            return true;
        }

        public bool IsUpdateBlogExists(int blogID, string title)
        {
            var record = _context.tblBlog.Where(x => x.Title == title && x.BlogID != blogID&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            if (record==null)
            {
                return false;
            }
            return true;
        }

        public bool IsUpdateCMSExists(int cMSId, string pageName)
        {
            var updatecmsrecord = _context.tblCMS.Where(x => x.PageName == pageName && x.CMSId != cMSId&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            if (updatecmsrecord==null)
            {
                return false;
            }
            return true;
        }

        public bool IsUpdateCollegeExists(string name, int collegeId)
        {
            var updatecollegerecord = _context.tblCollege.Where(x => x.Name == name && x.CollegeId != collegeId&&x.IsActive && !x.IsDeleted).SingleOrDefault();
            if (updatecollegerecord==null)
            {
                return false;
            }
            return true;
        }

        public string UploadBlogimage(tblBlog model)
        {
            string filename = null;
            if (model.imgurl != null)
            {
                if (model.imgurl.ContentType == "image/jpeg" || model.imgurl.ContentType == "image/png" || model.imgurl.ContentType == "image/jpg")
                {
                    string path = Path.Combine(_IWebHostEnvironment.WebRootPath, "ApplicationDocument/BlogImages");
                    filename = model.BlogID+"-"+model.Title + "-" + model.imgurl.FileName;
                    string filepath = Path.Combine(path, filename);
                    using (var filestream = new FileStream(filepath, FileMode.Create))
                    {
                        model.imgurl.CopyTo(filestream);
                    }
                    return filename;
                }
            }
            return filename;
        }

        public string UploadCourseimage(CourseViewModel model)
        {
            string filename = null;
            if (model.Image != null)
            {
                if (model.Image.ContentType == "image/jpeg" || model.Image.ContentType == "image/png" || model.Image.ContentType == "image/jpg")
                {
                    string path = Path.Combine(_IWebHostEnvironment.WebRootPath, "ApplicationDocument/CourseImages");
                    filename =model.CourseID+"-"+ model.Name + "-" + model.Image.FileName;
                    string filepath = Path.Combine(path, filename);
                    using (var filestream = new FileStream(filepath, FileMode.Create))
                    {
                        model.Image.CopyTo(filestream);
                    }
                    return filename;
                }
            }
            return filename;
        }

        public string Uploadimage(CollegeViewModel model)
        {
            string filename = null;
            if (model.Logo!=null)
            {
                if (model.Logo.ContentType == "image/jpeg" || model.Logo.ContentType == "image/png" || model.Logo.ContentType == "image/jpg")
                {
                    string path = Path.Combine(_IWebHostEnvironment.WebRootPath, "ApplicationDocument/UniversityImages");
                    filename = model.Name+"-"+model.Logo.FileName;
                    string filepath = Path.Combine(path, filename);
                    using (var filestream = new FileStream(filepath, FileMode.Create))
                    {
                        model.Logo.CopyTo(filestream);
                    }
                    return filename;
                }
            }
            return filename;
        }

        public string Uploadimage1(CollegeViewModel model)
        {
            string filename = null;
            if (model.SampleCertificate != null)
            {
                if (model.SampleCertificate.ContentType == "image/jpeg" || model.SampleCertificate.ContentType == "image/png" || model.SampleCertificate.ContentType == "image/jpg")
                {
                    string path = Path.Combine(_IWebHostEnvironment.WebRootPath, "ApplicationDocument/SampleCertificate");
                    filename = model.Name + "-" + model.SampleCertificate.FileName;
                    string filepath = Path.Combine(path, filename);
                    using (var filestream = new FileStream(filepath, FileMode.Create))
                    {
                        model.SampleCertificate.CopyTo(filestream);
                    }
                    return filename;
                }
            }
            return filename;
        }
    }
}
