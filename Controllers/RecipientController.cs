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
    public class RecipientController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly ICollege _college;
        private readonly EducationPortalDBContext _con;
        public readonly IWebHostEnvironment _IWebHostEnvironment;
        private readonly ILogger<RecipientController> _logger;
        public RecipientController(ICollege college, ILogger<RecipientController> logger, IWebHostEnvironment IWebHostEnvironment, IUser user, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _logger = logger;
            _rolePrivileges = rolePrivileges;
            _user = user;
            _college = college;
            _IWebHostEnvironment = IWebHostEnvironment;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid") > 0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("Recipient Index Page Accessed");
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
                    tblRecipient objcms = new tblRecipient();
                    if (string.IsNullOrEmpty(id))
                    {
                        _logger.LogInformation("Recipient Add Page Accessed");
                    }
                    else
                    {
                        var cmsID = int.Parse(id);
                        objcms = _college.GetRecipientDetailByUserID(cmsID);
                        if (objcms == null)
                        {
                            return RedirectToAction("Index", "Recipient", new { Msg = "drop" });
                        }
                        _logger.LogInformation("Recipient Update Page Accessed");
                    }
                    return View(objcms);
                }
                catch
                {
                    return RedirectToAction("Index", "Recipient", new { Msg = "error" });
                }
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult Save(tblRecipient objtbl)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            if (objtbl.RecipientID == 0)
            {
                if (_college.IsExistRecipient(objtbl.Email))
                {
                    TempData["fail"] = "Name Already Exist";
                    return View(objtbl);
                }
                objtbl.CreatedBy = HttpContext.Session.GetInt32("uid");
                objtbl.CreatedDate = DateTime.Now;
                _college.AddRecipient(objtbl);
                TempData["success"] = "Recipient Added Successfully";
                _logger.LogInformation("Recipient Added Successfully");
                return RedirectToAction("Index", "Recipient");
            }
            var userDetail = _college.GetRecipientDetailByUserID(objtbl.RecipientID);
            if (userDetail == null)
            {
                return RedirectToAction("Index", "Recipient");
            }
            if (_college.IsExistUpdateRecipient(objtbl.Email, objtbl.RecipientID))
            {
                TempData["fail"] = "Name Already Exist";
                return View(objtbl);
            }
            objtbl.UpdatedBy = HttpContext.Session.GetInt32("uid");
            objtbl.UpdatedDate = DateTime.Now;
            _college.EditRecipient(objtbl);
            TempData["success"] = "Recipient Updated Successfully";
            _logger.LogInformation("Recipient Updated Succefully");
            return RedirectToAction("Index", "Recipient");
        }

        [HttpPost]
        public IActionResult Delete(string[] recipientID)
        {
            try
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                if (recipientID.Length > 0)
                {
                    _college.DeleteRecipient(recipientID);
                    _logger.LogInformation("Recipient Deleted Succefully");
                    return RedirectToAction("Index", "Recipient", new { Msg = "deleted" });
                }
                else
                {
                    return RedirectToAction("Index", "Recipient", new { Msg = "NoSelect" });
                }
            }
            catch (Exception _exception)
            {
                if (_exception.InnerException != null && (_exception.InnerException.Message.Contains(GlobalCode.foreignKeyReference) || ((_exception.InnerException).InnerException).Message.Contains(GlobalCode.foreignKeyReference)))
                {
                    return RedirectToAction("Index", "Recipient", new { Msg = "inuse" });
                }
                return RedirectToAction("Index", "Recipient", new { Msg = "error" });
            }
        }

        public IActionResult Details(string id)
        {
            if (HttpContext.Session.GetInt32("uid") > 0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                var record = _con.tblRecipient.Where(x => x.RecipientID == Convert.ToInt32(id)).FirstOrDefault();
                _logger.LogInformation("Recipient Details Page Accessed");
                return View(record);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult<IList<tblRecipient>> _AjaxBinding()
        {
            var userList = _college.BindRecipient().Where(x => x.IsActive && !x.IsDeleted).OrderByDescending(c => c.RecipientID).ToList();
            return Json(userList);
        }
    }
}
