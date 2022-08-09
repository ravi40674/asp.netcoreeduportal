using EducationPortal.Common;
using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using EducationPortal.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Controllers
{
    public class CollegeCourseController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly ICollege _college;
        private readonly EducationPortalDBContext _con;
        private readonly ILogger<CollegeCourseController> _logger;
        public CollegeCourseController( ICollege college, ILogger<CollegeCourseController> logger, IUser user, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _rolePrivileges = rolePrivileges;
            _user = user;
            _logger = logger;
            _college = college;
        }

        public IActionResult Index(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                tblCollegeCourse objtbl = new tblCollegeCourse();
                List<tblCollegeCourse> courseList= _college.CollegeCoursegetById(id);
                CourseCollegeViewModel objmodel = new CourseCollegeViewModel();
                objmodel.CollegeId = Convert.ToInt32(id);
                objmodel.CourseId = courseList;
                objmodel.CourseName = _con.tblCourse.Where(x => _con.tblCollegeCourse.Any(x2 => x2.CollegeId == Convert.ToInt32(id) && x2.CourseId == x.CourseID&&!x2.IsDeleted)).ToList();
                ViewBag.Idcount = _con.tblCollegeCourse.Where(x => x.CollegeId == Convert.ToInt32(id)&&!x.IsDeleted).Count();
               int[] netrecord  = _con.tblCollegeCourse.Where(x => x.CollegeId == Convert.ToInt32(id)&&!x.IsDeleted).Select(x=>x.CourseId).ToArray();
                int[] nm = _con.tblCollegeCourse.Where(x=>x.CollegeId==Convert.ToInt32(id)).Select(m=>m.CourseId).Distinct().ToArray();
                var wrecord = _con.tblCourse.Where(x => !_con.tblCollegeCourse.Any(x2 => x2.CollegeId == Convert.ToInt32(id) && x2.CourseId == x.CourseID && !x2.IsDeleted)).ToList();
                string[] name = _con.tblCategory.Where(x => x.IsActive && !x.IsDeleted).Select(c=>c.Name).ToArray();
                var srecord = (from i in _con.tblCourse
                               join o in _con.tblCourse on i.CourseID equals o.ParentId
                               where o.IsActive && !o.IsDeleted&&name.Contains(i.Name)&&!netrecord.Contains(o.CourseID)
                               select new tblCourse { 
                               CourseID=o.CourseID,
                               Name=o.Name
                               }).ToList();
                ViewBag.Count = srecord.Count();
                int[] courseids = new int[srecord.Count];
                string[] coursenames = new string[srecord.Count];
                for (int i = 0; i < srecord.Count; i++)
                {
                    courseids[i] = srecord[i].CourseID;
                    coursenames[i] = srecord[i].Name;
                }
                ViewBag.ids = courseids;
                ViewBag.names = coursenames;
                ViewBag.alls = new SelectList(srecord, "CourseID", "Name");
                ViewBag.allidnm = "ViewBag.ids" + "," + "ViewBag.names";
                var result = _con.tblCourse.Where(x => !_con.tblCollegeCourse.Any(x2 => x2.CollegeId == Convert.ToInt32(id) && x.CourseID == x2.CourseId)).ToList();
                objtbl.CollegeId = Convert.ToInt32(id);
                List<tblCollegeCourse> c = _college.CollegeCoursegetById(objtbl.CollegeId.ToString());
                _logger.LogInformation("University Course Page Accessed");
                return View(objmodel);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public IActionResult Index(CourseCollegeViewModel objtbl)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            int[] netrecords = _con.tblCollegeCourse.Where(x => x.CollegeId == objtbl.CollegeId && !x.IsDeleted).Select(x => x.CourseId).ToArray();
            string[] name = _con.tblCategory.Where(x => x.IsActive && !x.IsDeleted).Select(c => c.Name).ToArray();
            var srecord = (from i in _con.tblCourse
                           join o in _con.tblCourse on i.CourseID equals o.ParentId
                           where o.IsActive && !o.IsDeleted && name.Contains(i.Name)
                           select new tblCourse
                           {
                               CourseID = o.CourseID,
                               Name = o.Name
                           }).ToList();
            ViewBag.Count = srecord.Count();
            int[] courseids = new int[srecord.Count];
            string[] coursenames = new string[srecord.Count];
            for (int i = 0; i < srecord.Count; i++)
            {
                courseids[i] = srecord[i].CourseID;
                coursenames[i] = srecord[i].Name;
            }
            ViewBag.alls = new SelectList(srecord, "CourseID", "Name");
            string strcourse = Request.Form["duallistbox_demo1[]"];
            string[] strcoursearr = null;
            if (strcourse!=null)
            {
                strcoursearr = strcourse.Split(",");
                var result = _con.tblCollegeCourse.Where(x => x.CollegeId == objtbl.CollegeId &&!x.IsDeleted&& !strcoursearr.Contains(x.CourseId.ToString())).AsNoTracking().ToList();
                for (int kl = 0; kl < result.Count; kl++)
                {
                    var netrecord = _con.tblCollegeCourse.Where(x => x.CollegeCourseId == result[kl].CollegeCourseId).AsNoTracking().FirstOrDefault();
                    netrecord.IsDeleted = true;
                    _con.Entry(netrecord).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _con.SaveChanges();
                }
                var lastrecord = strcoursearr.Where(x=>!_con.tblCollegeCourse.Any(x2=>x2.CollegeId==objtbl.CollegeId&&x2.CourseId==Convert.ToInt32(x)&&!x2.IsDeleted)).ToList();
                if (lastrecord.Count>0)
                {
                    for (int jk = 0; jk < lastrecord.Count; jk++)
                    {
                        var existrecord = _con.tblCollegeCourse.Where(x => x.CollegeId == objtbl.CollegeId && x.CourseId == Convert.ToInt32(lastrecord[jk])).SingleOrDefault();
                        tblCollegeCourse obj = new tblCollegeCourse();
                        obj.CollegeId = objtbl.CollegeId;
                        obj.CourseId = Convert.ToInt32(lastrecord[jk]);
                        obj.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
                        obj.CreatedDate = DateTime.Now;
                        obj.IsActive = true;
                        obj.IsDeleted = objtbl.IsDeleted;
                        if (existrecord==null)
                        {
                         obj.IsDeleted = false;
                        _con.tblCollegeCourse.Add(obj);
                        }
                        else
                        {
                            existrecord.IsDeleted = false;
                            _con.Entry(existrecord).State=EntityState.Modified;
                        }
                        _con.SaveChanges();
                    }
                }
                else
                {
                    List<tblCollegeCourse> courseList = _college.CollegeCoursegetById(objtbl.CollegeId.ToString());
                    int i = 0;
                    foreach (var item in courseList)
                    {
                        tblCollegeCourse objmodtable = new tblCollegeCourse();
                        objmodtable.CollegeId = objtbl.CollegeId;
                        objmodtable.IsActive = true;
                        objmodtable.IsDeleted = false;
                        objmodtable.IsDeleted = objtbl.IsDeleted;
                        objmodtable.CourseId = item.CourseId;
                        objmodtable.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
                        objmodtable.ModifiedDate = DateTime.Now;
                        objmodtable.CollegeCourseId = item.CollegeCourseId;
                        _con.Entry(objmodtable).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        _con.SaveChanges();
                        i++;
                    }
                }
            }
            else
            {
                TempData["fail"] = "Please select Atleast 1 Course";
                return View(objtbl);
            }
            TempData["success"] = "Selected Course saved Successfully!";
            _logger.LogInformation("University Course Updated Successfully");
            return RedirectToAction("Index","College");
        }
    }
}
