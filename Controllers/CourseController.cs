using EducationPortal.Common;
using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using EducationPortal.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EducationPortal.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly EducationPortalDBContext _con;
        private readonly ICollege _college;
        public readonly IWebHostEnvironment _IWebHostEnvironment;
        private readonly ILogger<CourseController> _logger;
        public CourseController(IWebHostEnvironment IWebHostEnvironment, ILogger<CourseController> logger,ICollege college, IUser user, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _rolePrivileges = rolePrivileges;
            _logger = logger;
            _user = user;
            _college = college;
            _IWebHostEnvironment = IWebHostEnvironment;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("Course Index Page Accessed");
                return View();
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult SaveCourse(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                try
                {
                    ViewBag.Category = new SelectList(_user.CategoryBind(), "CategoryID", "Name");
                    ViewBag.Parent = new SelectList(_user.CourseBind(), "ParentId", "DisplayName");
                    CourseViewModel objrole = new CourseViewModel();
                    if (string.IsNullOrEmpty(id))
                    {
                        _logger.LogInformation("Course Add Page Accessed");
                        return View(objrole);
                    }
                    else
                    {
                        var userID = int.Parse(id);
                        objrole = _user.GetCourseDetailByUserID(userID);
                        if (objrole == null)
                        {
                            return RedirectToAction("Index", "Course", new { Msg = "drop" });
                        }
                        _logger.LogInformation("Course Update Page Accessed");
                        return View(objrole);
                    }
                }
                catch
                {
                    return RedirectToAction("Index", "Course", new { Msg = "error" });
                }
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult SaveCourse(CourseViewModel model)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            ViewBag.Category = new SelectList(_user.CategoryBind(), "CategoryID", "Name");
            ViewBag.Parent = new SelectList(_user.CourseBind(), "ParentId", "Name");
            tblCourse tblcourse = new tblCourse();
            if (model.CourseID == 0)
            {
                model.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
                tblcourse.CreatedBy = model.CreatedBy;
                tblcourse.CreatedDate = DateTime.Now;
                tblcourse.IsActive = model.IsActive;
                tblcourse.Name = model.Name;
                tblcourse.CategoryID = model.CategoryID;
                tblcourse.CourseID = model.CourseID;
                tblcourse.ParentId = model.ParentId;
                tblcourse.DisplayName = model.DisplayName;
                string uploadimage = _college.UploadCourseimage(model);
                if (uploadimage != null)
                {
                    tblcourse.Image = uploadimage;
                }
                else
                {
                    TempData["fail"] = "Please Upload .jpg or .jpeg or .png of any one Image file";
                    return View(model);
                }
                _con.tblCourse.Add(tblcourse);
                _con.SaveChanges();
                TempData["success"] = "Course Added Successfully";
                _logger.LogInformation("Course Added Successfully");
                return RedirectToAction("Index", "Course");
            }
            var userDetail = _user.GetCourseDetailByUserID(model.CourseID);
            if (userDetail == null)
            {
                return RedirectToAction("Index", "Course");
            }
            model.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
            tblcourse.ModifiedBy = model.ModifiedBy;
            tblcourse.ModifiedDate = DateTime.Now;
            tblcourse.DisplayName = model.DisplayName;
            tblcourse.IsActive = model.IsActive;
            tblcourse.Name = model.Name;
            tblcourse.CategoryID = model.CategoryID;
            tblcourse.CourseID = model.CourseID;
            tblcourse.ParentId = model.ParentId;
            string uploadimages = _college.UploadCourseimage(model);
            if (uploadimages == null)
            {
                if (userDetail.imgurl != null)
                {
                    tblcourse.Image = model.imgurl;
                }
                else
                {
                    TempData["fail"] = "Please Upload .jpg or .jpeg or .png of any one Image file";
                }
            }
            else
            {
                if (userDetail.imgurl!=uploadimages)
                {
                    var imgpath = Path.Combine(_IWebHostEnvironment.WebRootPath, "ApplicationDocument/CourseImages", userDetail.imgurl);
                    if (System.IO.File.Exists(imgpath))
                    {
                        System.IO.File.Delete(imgpath);
                    }
                }
                tblcourse.Image = uploadimages;
            }
            _con.Entry(tblcourse).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _con.SaveChanges();
            TempData["success"] = "Course Updated Successfully";
            _logger.LogInformation("Course Updated Successfully");
            return RedirectToAction("Index", "Course");
        }

        public IActionResult CourseDetails(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                var record = _con.tblCourse.Where(x => x.CourseID == Convert.ToInt32(id)).FirstOrDefault();
                _logger.LogInformation("Course Details Page Accessed");
                return View(record);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult DeleteCourse(string[] courseID)
        {
            try
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                if (courseID.Length > 0)
                {
                    _user.DeleteCourses(courseID);
                    _logger.LogInformation("Course Deleted Successfully");
                    return RedirectToAction("Index", "Course", new { Msg = "deleted" });
                }
                else
                {
                    return RedirectToAction("Index", "Course", new { Msg = "NoSelect" });
                }
            }
            catch (Exception _exception)
            {
                if (_exception.InnerException != null && (_exception.InnerException.Message.Contains(GlobalCode.foreignKeyReference) || ((_exception.InnerException).InnerException).Message.Contains(GlobalCode.foreignKeyReference)))
                {
                    return RedirectToAction("Index", "Course", new { Msg = "inuse" });
                }
                return RedirectToAction("Index", "Course", new { Msg = "error" });
            }
        }

        public ActionResult<IList<CourseViewModel>> _AjaxBindingCourse()
        {
            var userList = _user.BindCourseDetail().Where(x => x.IsActive && !x.IsDeleted).ToList();
            return Json(userList);
        }
    }
}
