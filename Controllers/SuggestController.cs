using EducationPortal.Common;
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
    public class SuggestController : Controller
    {
        private readonly IRolePrivileges _rolePrivileges;
        private readonly ICollege _college;
        private readonly ILogger<SuggestController> _logger;
        public SuggestController(IRolePrivileges rolePrivileges, ILogger<SuggestController> logger,ICollege college)
        {
            _rolePrivileges = rolePrivileges;
            _college = college;
            _logger = logger;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("Suggest Index Page Accessed");
                return View();
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult<IList<tblSuggest>> _AjaxBindingSuggest()
        {
            var suggestList = _college.BindSuggest().OrderByDescending(c=>c.SuggestID).ToList();
            return Json(suggestList);
        }
    }
}
