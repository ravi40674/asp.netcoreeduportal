using EducationPortal.Common;
using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EducationPortal.Controllers
{
    public class CollegeSemesterController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly EducationPortalDBContext _con;
        private readonly ILogger<CollegeSemesterController> _logger;
        public CollegeSemesterController(IUser user, ILogger<CollegeSemesterController> logger, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _rolePrivileges = rolePrivileges;
            _logger = logger;
            _user = user;
        }
        public IActionResult Index(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                try
                {
                    ViewBag.Course = new SelectList(_user.CoursesBind(), "CourseID", "Name");
                    tblCollegeSemester objtbl = new tblCollegeSemester();
                    var userID = int.Parse(id);
                    var tbl = _user.GetCourseSemesterByUserID(userID);
                    var record = _con.tblCollegeSemester.Where(x => x.CollegeId == Convert.ToInt32(id)).Count();
                    if (record==0)
                    {
                        objtbl.CollegeId = Convert.ToInt32(id);
                        return View(objtbl);
                    }
                    _logger.LogInformation("University Semester Page Accessed");
                    return View(tbl);
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
        public IActionResult Index(tblCollegeSemester objtbl)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            ViewBag.Course = new SelectList(_user.CourseBind(), "CourseID", "Name");
            tblCollegeSemester obj = new tblCollegeSemester();
            var record = _con.tblCollegeSemester.Where(x => x.CollegeId == objtbl.CollegeId).Count();
            var coursesemester = _con.tblCollegeSemester.Where(x => x.CollegeId == objtbl.CollegeId).AsNoTracking().FirstOrDefault();
            obj.CollegeId = objtbl.CollegeId;
            obj.CourseId = objtbl.CourseId;
            obj.IsActive = objtbl.IsActive;
            obj.SemesterFee = objtbl.SemesterFee;
            obj.OtherNotes = objtbl.OtherNotes;
            if (record==0)
            {
                obj.CreatedDate = DateTime.Now;
                obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
                _con.tblCollegeSemester.Add(obj);
            }
            else
            {
                obj.ModifiedDate = DateTime.Now;
                obj.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
                obj.CollegeSemesterId = coursesemester.CollegeSemesterId;
                _con.Entry(obj).State = EntityState.Modified;
            }
            _con.SaveChanges();

            TempData["success"] = "Semester Course Saved Successfully";
            _logger.LogInformation("University Semester Updated Successfully");
            return RedirectToAction("Index", "College");
        }
    }
}
