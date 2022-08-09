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
    public class CMSController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly ICollege _college;
        private readonly EducationPortalDBContext _con;
        private readonly ILogger<CMSController> _logger;
        public CMSController( ICollege college, ILogger<CMSController> logger, IUser user, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _rolePrivileges = rolePrivileges;
            _user = user;
            _college = college;
            _logger = logger;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("CMS Index Page Accessed");
                return View();
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult SaveCMS(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                try
                {
                    tblCMS objcms = new tblCMS();
                    if (string.IsNullOrEmpty(id))
                    {
                        _logger.LogInformation("CMS Add Page Accessed");
                    }
                    else
                    {
                        var cmsID = int.Parse(id);
                        objcms = _college.GetCMSDetailByUserID(cmsID);
                        if (objcms == null)
                        {
                            return RedirectToAction("Index", "CMS", new { Msg = "drop" });
                        }
                        _logger.LogInformation("CMS Update Page Accessed");
                    }
                    return View(objcms);
                }
                catch
                {
                    return RedirectToAction("Index", "CMS", new { Msg = "error" });
                }
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult SaveCMS(tblCMS objtbl)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            if (objtbl.CMSId == 0)
            {
                if (_college.IsCMsExists(objtbl.PageName))
                {
                    TempData["fail"] = "CMS Name Already Exist";
                    return View();
                }
                else
                {
                    _college.AddCMS(objtbl);
                    TempData["success"] = "CMS Added Successfully";
                    _logger.LogInformation("CMS Added Successfully");
                    return RedirectToAction("Index", "CMS");
                }
            }
            var userDetail = _college.GetCMSDetailByUserID(objtbl.CMSId);
            if (userDetail == null)
            {
                return RedirectToAction("Index", "CMS");
            }

            if (_college.IsUpdateCMSExists(objtbl.CMSId, objtbl.PageName))
            {
                TempData["fail"] = "CMS Already Exist";
                return View(objtbl);
            }
            _college.EditCMS(objtbl);
            TempData["success"] = "CMS Updated Successfully";
            _logger.LogInformation("CMS Updated Successfully");
            return RedirectToAction("Index", "CMS");
        }

        [HttpPost]
        public IActionResult DeleteCMS(string[] cMSID)
        {
            try
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                if (cMSID.Length > 0)
                {
                    _college.DeleteCMS(cMSID);
                    _logger.LogInformation("CMS Deleted Successfully");
                    return RedirectToAction("Index", "CMS", new { Msg = "deleted" });
                }
                else
                {
                    return RedirectToAction("Index", "CMS", new { Msg = "NoSelect" });
                }
            }
            catch (Exception _exception)
            {
                if (_exception.InnerException != null && (_exception.InnerException.Message.Contains(GlobalCode.foreignKeyReference) || ((_exception.InnerException).InnerException).Message.Contains(GlobalCode.foreignKeyReference)))
                {
                    return RedirectToAction("Index", "CMS", new { Msg = "inuse" });
                }
                return RedirectToAction("Index", "CMS", new { Msg = "error" });
            }
        }

        public IActionResult CMSDetails(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                var record = _con.tblCMS.Where(x => x.CMSId == Convert.ToInt32(id)).FirstOrDefault();
                _logger.LogInformation("CMS Details Page Accessed");
                return View(record);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult<IList<tblCMS>> _AjaxBindingCMS()
        {
            var userList = _college.BindCMS().Where(x => x.IsActive && !x.IsDeleted).OrderByDescending(c=>c.CMSId).ToList();
            return Json(userList);
        }
    }
}
