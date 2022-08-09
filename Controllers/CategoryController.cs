using EducationPortal.Common;
using EducationPortal.Context;
using EducationPortal.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EducationPortal.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly EducationPortalDBContext _con;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(IUser user, ILogger<CategoryController> logger, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _rolePrivileges = rolePrivileges;
            _user = user;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("Category Index Page Accessed");
                return View();
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult DeleteCategory(string[] categoryID)
        {
            try
            {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                if (categoryID.Length > 0)
                {
                    _user.DeleteCategorys(categoryID);
                    _logger.LogInformation("Category Deleted Successfully");
                    return RedirectToAction("Index", "Role", new { Msg = "deleted" });
                }
                else
                {
                    return RedirectToAction("Index", "Role", new { Msg = "NoSelect" });
                }
            }
            catch (Exception _exception)
            {
                if (_exception.InnerException != null && (_exception.InnerException.Message.Contains(GlobalCode.foreignKeyReference) || ((_exception.InnerException).InnerException).Message.Contains(GlobalCode.foreignKeyReference)))
                {
                    return RedirectToAction("Index", "Role", new { Msg = "inuse" });
                }
                return RedirectToAction("Index", "Role", new { Msg = "error" });
            }
        }

        public IActionResult CategoryDetails(int id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                var record = _con.tblCategory.Where(x => x.CategoryID == id).FirstOrDefault();
                _logger.LogInformation("Category Details Page Accessed");
                return View(record);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
