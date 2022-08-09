using EducationPortal.Common;
using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Controllers
{
    public class SuggessionController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly ICollege _college;
        private readonly EducationPortalDBContext _con;
        private readonly ILogger<SuggessionController> _logger;
        public SuggessionController(ICollege college, ILogger<SuggessionController> logger, IUser user, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _logger = logger;
            _rolePrivileges = rolePrivileges;
            _user = user;
            _college = college;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                return View();
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult SaveSpecialization(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                try
                {
                    ViewBag.Course = new SelectList(_college.CourseBind(), "CourseID", "Name");
                    tblSpecialization objtblspec = new tblSpecialization();
                    if (!string.IsNullOrEmpty(id))
                    {
                        var userID = int.Parse(id);
                        objtblspec = _college.GetSpecializationDetailByID(userID);
                        if (objtblspec == null)
                        {
                            return RedirectToAction("Index", "Suggession", new { Msg = "drop" });
                        }
                    }
                    return View(objtblspec);
                }
                catch
                {
                    return RedirectToAction("Index", "Suggession", new { Msg = "error" });
                }
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult SaveSpecialization(tblSpecialization objtbl)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            ViewBag.Course = new SelectList(_college.CourseBind(), "CourseID", "Name");
            if (objtbl.SpecializationID > 0)
            {
                if (_college.IsSpecializationUpdateExists(objtbl.Name, objtbl.SpecializationID,objtbl.CourseID))
                {
                    TempData["fail"] = "Speacialization Name Already Exists";
                    return View(objtbl);
                }
                objtbl.UpdatedBy = HttpContext.Session.GetInt32("uid");
                objtbl.UpdatedDate = DateTime.Now;
                _con.Entry(objtbl).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _con.SaveChanges();
                TempData["success"] = "Speacialization updated Successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                if (_college.IsSpecializationExists(objtbl.Name,objtbl.CourseID))
                {
                    TempData["fail"] = "Speacialization Name Already Exists";
                    return View();
                }
                objtbl.CreatedBy = HttpContext.Session.GetInt32("uid");
                objtbl.CreatedDate = DateTime.Now;
                _con.tblSpecialization.Add(objtbl);
                _con.SaveChanges();
                TempData["success"] = "Speacialization added Successfully!";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Deletespecialization(string[] specializationID)
        {
            try
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                if (specializationID.Length > 0)
                {
                    _college.DeleteSpecialization(specializationID);
                    return RedirectToAction("Index", "Suggession", new { Msg = "deleted" });
                }
                else
                {
                    return RedirectToAction("Index", "Suggession", new { Msg = "NoSelect" });
                }
            }
            catch (Exception _exception)
            {
                if (_exception.InnerException != null && (_exception.InnerException.Message.Contains(GlobalCode.foreignKeyReference) || ((_exception.InnerException).InnerException).Message.Contains(GlobalCode.foreignKeyReference)))
                {
                    return RedirectToAction("Index", "Suggession", new { Msg = "inuse" });
                }
                return RedirectToAction("Index", "Suggession", new { Msg = "error" });
            }
        }
        public ActionResult<IList<tblSpecialization>> _AjaxBindingSpecialization()
        {
            var record= _college.BindSpecializationDetail().Where(x => x.IsActive && !x.IsDeleted).OrderByDescending(c=>c.SpecializationID).ToList();
            return Json(record);
        }
    }
}
