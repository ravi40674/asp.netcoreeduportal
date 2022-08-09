using EducationPortal.Common;
using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
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
    public class EmailTemplateController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly ICollege _college;
        private readonly EducationPortalDBContext _con;
        public readonly IWebHostEnvironment _IWebHostEnvironment;
        private readonly ILogger<EmailTemplateController> _logger;
        public EmailTemplateController(ICollege college, ILogger<EmailTemplateController> logger, IWebHostEnvironment IWebHostEnvironment, IUser user, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
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
            if (HttpContext.Session.GetInt32("uid") > 0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("Email Template Index Page Accessed");
                return View();
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult Save(string id)
        {
            if (HttpContext.Session.GetInt32("uid") > 0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                try
                {
                    tblTemplate objcms = new tblTemplate();
                    if (string.IsNullOrEmpty(id))
                    {
                        _logger.LogInformation("Email Template Add Page Accessed");
                    }
                    else
                    {
                        var cmsID = int.Parse(id);
                        objcms = _college.GetTemplateDetailByUserID(cmsID);
                        if (objcms == null)
                        {
                            return RedirectToAction("Index", "EmailTemplate", new { Msg = "drop" });
                        }
                        _logger.LogInformation("Email Template Update Page Accessed");
                    }
                    return View(objcms);
                }
                catch
                {
                    return RedirectToAction("Index", "EmailTemplate", new { Msg = "error" });
                }
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult Save(tblTemplate objtbl)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            if (objtbl.Description == null)
            {
                return View(objtbl);
            }
            if (objtbl.TemplateID == 0)
            {
                if (_college.IsExistTemplate(objtbl.Name))
                {
                    TempData["fail"] = "Name Already Exist";
                    return View(objtbl);
                }
                objtbl.CreatedBy = HttpContext.Session.GetInt32("uid");
                objtbl.CreatedDate = DateTime.Now;
                _college.AddTemplate(objtbl);
                TempData["success"] = "Template Added Successfully";
                _logger.LogInformation("Email Template Added Succefully");
                return RedirectToAction("Index", "EmailTemplate");
            }
            var userDetail = _college.GetTemplateDetailByUserID(objtbl.TemplateID);
            if (userDetail == null)
            {
                return RedirectToAction("Index", "EmailTemplate");
            }
            if (_college.IsExistUpdateTemplate(objtbl.Name,objtbl.TemplateID))
            {
                TempData["fail"] = "Name Already Exist";
                return View(objtbl);
            }
            objtbl.UpdatedBy = HttpContext.Session.GetInt32("uid");
            objtbl.UpdatedDate = DateTime.Now;
            _college.EditTemplate(objtbl);
            TempData["success"] = "Template Updated Successfully";
            _logger.LogInformation("Email Template Updated Successfully");
            return RedirectToAction("Index", "EmailTemplate");
        }

        [HttpPost]
        public IActionResult Delete(string[] templateID)
        {
            try
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                if (templateID.Length > 0)
                {
                    _college.DeleteTemplate(templateID);
                    _logger.LogInformation("Email Template Deleted Successfully");
                    return RedirectToAction("Index", "EmailTemplate", new { Msg = "deleted" });
                }
                else
                {
                    return RedirectToAction("Index", "EmailTemplate", new { Msg = "NoSelect" });
                }
            }
            catch (Exception _exception)
            {
                if (_exception.InnerException != null && (_exception.InnerException.Message.Contains(GlobalCode.foreignKeyReference) || ((_exception.InnerException).InnerException).Message.Contains(GlobalCode.foreignKeyReference)))
                {
                    return RedirectToAction("Index", "EmailTemplate", new { Msg = "inuse" });
                }
                return RedirectToAction("Index", "EmailTemplate", new { Msg = "error" });
            }
        }

        public IActionResult Details(string id)
        {
            if (HttpContext.Session.GetInt32("uid") > 0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                var record = _con.tblTemplate.Where(x => x.TemplateID == Convert.ToInt32(id)).FirstOrDefault();
                _logger.LogInformation("Email Template Details Page Accessed");
                return View(record);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult<IList<tblTemplate>> _AjaxBinding()
        {
            var userList = _college.BindTemplate().Where(x => x.IsActive && !x.IsDeleted).OrderByDescending(c => c.TemplateID).ToList();
            return Json(userList);
        }
    }
}
