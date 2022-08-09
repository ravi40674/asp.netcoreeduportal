using EducationPortal.Common;
using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using EducationPortal.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EducationPortal.Controllers
{
    public class CollegeController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly ICollege _college;
        private readonly EducationPortalDBContext _con;
        public readonly IWebHostEnvironment _IWebHostEnvironment;
        private readonly ILogger<CollegeController> _logger;
        public CollegeController(IWebHostEnvironment IWebHostEnvironment, ILogger<CollegeController> logger, ICollege college,IUser user, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _rolePrivileges = rolePrivileges;
            _user = user;
            _logger = logger;
            _college = college;
            _IWebHostEnvironment = IWebHostEnvironment;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("University Index Page Accessed");
                return View();
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }
        public IActionResult CollegeDetails(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                var record = _con.tblCollege.Where(x => x.CollegeId == Convert.ToInt32(id)).FirstOrDefault();
                _logger.LogInformation("University Details Page Accessed");
                return View(record);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }
        public IActionResult SaveCollege(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                try
                {
                    CollegeViewModel objtblcollege = new CollegeViewModel();
                    if (string.IsNullOrEmpty(id))
                    {
                        _logger.LogInformation("University Add Page Accessed");
                        return View(objtblcollege);
                    }
                    else
                    {
                        var userID = int.Parse(id);
                        objtblcollege = _college.GetCollegeDetailByCollegeID(userID);
                        if (objtblcollege == null)
                        {
                            return RedirectToAction("Index", "College", new { Msg = "drop" });
                        }
                        _logger.LogInformation("University Update Page Accessed");
                        return View(objtblcollege);
                    }
                }
                catch
                {
                    return RedirectToAction("Index", "College", new { Msg = "error" });
                }
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult SaveCollege(CollegeViewModel model)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            tblCollege objtblcollege = new tblCollege();
            if (model.CollegeId == 0)
            {
                    if (_college.IsCollegeExists(model.Name))
                    {
                        TempData["fail"] = "University Name Already Exist";
                        return View(model);
                    }
                    else
                    {
                        model.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
                        objtblcollege.CreatedBy = model.CreatedBy;
                        objtblcollege.CreatedDate = DateTime.Now;
                        objtblcollege.IsActive = model.IsActive;
                        objtblcollege.Name = model.Name;
                        objtblcollege.Rating = model.Rating;
                        objtblcollege.RatingType = model.RatingType;
                        objtblcollege.Approvals = model.Approvals;
                        objtblcollege.Collegescore = model.Collegescore;
                        objtblcollege.Cons = model.Cons;
                        objtblcollege.EducationMode = model.EducationMode;
                        objtblcollege.ELearnings = model.ELearnings;
                        objtblcollege.Eligibility = model.Eligibility;
                        objtblcollege.Emi = model.Emi;
                        objtblcollege.IndustryReady = model.IndustryReady;
                        objtblcollege.NaacScore = model.NaacScore;
                        objtblcollege.NirfRank = model.NirfRank;
                        objtblcollege.OnlineClasses = model.OnlineClasses;
                        objtblcollege.PlacementAssistance = model.PlacementAssistance;
                        objtblcollege.Pros = model.Pros;
                        objtblcollege.Rating = model.Rating;
                        objtblcollege.RatingType = model.RatingType;
                        objtblcollege.SatisfiedStudents = model.SatisfiedStudents;
                        objtblcollege.StudentsEnrolled = model.StudentsEnrolled;
                        objtblcollege.StudentsRating = model.StudentsRating;
                        objtblcollege.WesApproval = model.WesApproval;
                        string uploadimage = _college.Uploadimage(model);
                        string uploadimage1 = _college.Uploadimage1(model);
                        if (uploadimage != null)
                        {
                            objtblcollege.Logo = uploadimage;
                        }
                        else
                        {
                            TempData["fail"] = "Please Upload .jpg or .jpeg or .png of any one Image file";
                            return View(model);
                        }
                        if (uploadimage1 != null)
                        {
                            objtblcollege.SampleCertificate = uploadimage1;
                        }
                        else
                        {
                            TempData["fail"] = "Please Upload .jpg or .jpeg or .png of any one Image file";
                            return View(model);
                        }
                        _con.tblCollege.Add(objtblcollege);
                        _con.SaveChanges();
                        TempData["success"] = "University Added Successfully";
                        _logger.LogInformation("University Added Successfully");
                        return RedirectToAction("Index", "College");
                    }
                }
                else
                {
                CollegeViewModel userDetail = new CollegeViewModel();
                if (model.Logo!=null)
                {
                    userDetail = _college.GetCourseDetailByCollegeID(model.CollegeId, model.Logo.FileName);
                }
                else
                {
                    userDetail = _college.GetCourseDetailByCollegeID(model.CollegeId, model.imgurl);
                }
                if (model.SampleCertificate!=null)
                {
                    userDetail = _college.GetCourseDetailByCollegeID(model.CollegeId, model.SampleCertificate.FileName);
                }
                else
                {
                    userDetail = _college.GetCourseDetailByCollegeID(model.CollegeId, model.imgurl2);
                }
                if (userDetail == null)
                    {
                        return RedirectToAction("Index", "College");
                    }

                    if (_college.IsUpdateCollegeExists(model.Name, model.CollegeId))
                    {
                        TempData["fail"] = "University Name Already Exist";
                        return View(userDetail);
                    }
                    model.UpdatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
                    objtblcollege.CollegeId = model.CollegeId;
                    objtblcollege.UpdatedBy = model.UpdatedBy;
                    objtblcollege.UpdatedDate = DateTime.Now;
                    objtblcollege.IsActive = model.IsActive;
                    objtblcollege.Name = model.Name;
                    objtblcollege.Rating = model.Rating;
                    objtblcollege.RatingType = model.RatingType;
                    objtblcollege.Approvals = model.Approvals;
                    objtblcollege.Collegescore = model.Collegescore;
                    objtblcollege.Cons = model.Cons;
                    objtblcollege.EducationMode = model.EducationMode;
                    objtblcollege.ELearnings = model.ELearnings;
                    objtblcollege.Eligibility = model.Eligibility;
                    objtblcollege.Emi = model.Emi;
                    objtblcollege.IndustryReady = model.IndustryReady;
                    objtblcollege.NaacScore = model.NaacScore;
                    objtblcollege.NirfRank = model.NirfRank;
                    objtblcollege.OnlineClasses = model.OnlineClasses;
                    objtblcollege.PlacementAssistance = model.PlacementAssistance;
                    objtblcollege.Pros = model.Pros;
                    objtblcollege.SatisfiedStudents = model.SatisfiedStudents;
                    objtblcollege.StudentsEnrolled = model.StudentsEnrolled;
                    objtblcollege.StudentsRating = model.StudentsRating;
                    objtblcollege.WesApproval = model.WesApproval;
                    string uploadimage = _college.Uploadimage(model);
                    string uploadimage1 = _college.Uploadimage1(model);
                    if (uploadimage == null)
                    {
                        if (userDetail.imgurl != null)
                        {
                            objtblcollege.Logo = model.imgurl;
                        }
                        else
                        {
                            TempData["fail"] = "Please Upload .jpg or .jpeg or .png of any one Image file";
                        }
                    }
                    else
                    {
                    if (userDetail.imgurl!=uploadimage)
                    {
                        var imgpath = Path.Combine(_IWebHostEnvironment.WebRootPath, "ApplicationDocument/UniversityImages", userDetail.imgurl);
                        if (System.IO.File.Exists(imgpath))
                        {
                            System.IO.File.Delete(imgpath);
                        }
                    }
                    objtblcollege.Logo = uploadimage;
                    }
                    if (uploadimage1 == null)
                    {
                        if (userDetail.imgurl2 != null)
                        {
                            objtblcollege.SampleCertificate = model.imgurl2;
                        }
                        else
                        {
                            TempData["fail"] = "Please Upload .jpg or .jpeg or .png of any one Image file";
                        }
                    }
                    else
                    {
                    if (userDetail.imgurl2!=uploadimage1)
                    {
                        var imgpath = Path.Combine(_IWebHostEnvironment.WebRootPath, "ApplicationDocument/SampleCertificate", userDetail.imgurl2);
                        if (System.IO.File.Exists(imgpath))
                        {
                            System.IO.File.Delete(imgpath);
                        }
                    }
                    objtblcollege.SampleCertificate = uploadimage1;
                    }
                  }
                    _con.Entry(objtblcollege).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _con.SaveChanges();
                    TempData["success"] = "University Updated Successfully";
                    _logger.LogInformation("University Updated Successfully");
                    return RedirectToAction("Index", "College");
        }

        [HttpPost]
        public IActionResult DeleteCollege(string[] collegeId)
        {
            try
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                if (collegeId.Length > 0)
                {
                    _college.DeleteCollege(collegeId);
                    _logger.LogInformation("University Deleted Successfully");
                    return RedirectToAction("Index", "College", new { Msg = "deleted" });
                }
                else
                {
                    return RedirectToAction("Index", "College", new { Msg = "NoSelect" });
                }
            }
            catch (Exception _exception)
            {
                if (_exception.InnerException != null && (_exception.InnerException.Message.Contains(GlobalCode.foreignKeyReference) || ((_exception.InnerException).InnerException).Message.Contains(GlobalCode.foreignKeyReference)))
                {
                    return RedirectToAction("Index", "College", new { Msg = "inuse" });
                }
                return RedirectToAction("Index", "College", new { Msg = "error" });
            }
        }
        public ActionResult<IList<CollegeViewModel>> _AjaxBindingCollege()
        {
            var list = _college.CollegeListBind().Where(x=>x.IsActive && !x.IsDeleted).OrderByDescending(c=>c.CollegeId).ToList();
            return Json(list);
        }
    }
}
