using EducationPortal.Common;
using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EducationPortal.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly EducationPortalDBContext _con;
        private readonly ILogger<UserController> _logger;
        public UserController(IUser user, IRolePrivileges rolePrivileges, ILogger<UserController> logger, EducationPortalDBContext con)
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
                UserViewModel objUserViewModel = new UserViewModel();
                BindRoleDropDown(objUserViewModel);
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("User Index Page Accessed");
                return View(objUserViewModel);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }
        private UserViewModel BindRoleDropDown(UserViewModel objUserViewModel)
        {
            objUserViewModel.SelectRole = new SelectList(_user.GetRoleList(0, string.Empty), "RoleID", "roleneme");
            return objUserViewModel;
        }

        public IActionResult DetailUser(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                var userDetails = _con.tblUser.Where(x => x.UserID == Convert.ToInt32(id)).FirstOrDefault();
                _logger.LogInformation("User Details Page Accessed");
                return View(userDetails);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
