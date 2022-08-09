using EducationPortal.Common;
using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Controllers
{
    public class CourseInquiryController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly ICollege _college;
        private readonly EducationPortalDBContext _con;
        private readonly ILogger<CourseInquiryController> _logger;
        public CourseInquiryController(ICollege college, ILogger<CourseInquiryController> logger, IUser user, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _rolePrivileges = rolePrivileges;
            _user = user;
            _logger = logger;
            _college = college;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("Course Inquiry Index Page Accessed");
                return View();
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult<IList<tblCourseInquiry>> _AjaxBindingCourseInquiry()
        {
            var userList = _college.BindCourseInquiry().OrderByDescending(c=>c.CourseInquiryId).ToList();
            return Json(userList);
        }
    }
}
