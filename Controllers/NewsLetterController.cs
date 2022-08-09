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
    public class NewsLetterController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly EducationPortalDBContext _con;
        private readonly ICollege _college;
        public readonly IWebHostEnvironment _IWebHostEnvironment;
        private readonly ILogger<NewsLetterController> _logger;
        public NewsLetterController(IWebHostEnvironment IWebHostEnvironment, ILogger<NewsLetterController> logger, ICollege college, IUser user, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
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
                _logger.LogInformation("News Letter Index Page Accessed");
                return View();
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult Details(string id)
        {
            if (HttpContext.Session.GetInt32("uid") > 0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                var record = _con.tblNewsLetter.Where(x => x.NewsLetterID == Convert.ToInt32(id)).FirstOrDefault();
                _logger.LogInformation("News Letter Details Page Accessed");
                return View(record);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult Delete(string[] newsLetterID)
        {
            try
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                if (newsLetterID.Length > 0)
                {
                    _user.Delete(newsLetterID);
                    _logger.LogInformation("News Letter Deleted Successfully");
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

        public ActionResult<IList<tblNewsLetter>> _AjaxBinding()
        {
            return Json(_user.BindDetail().Where(x => x.IsSubscribed && !x.IsDeleted).OrderByDescending(c=>c.NewsLetterID).ToList());
        }
    }
}
