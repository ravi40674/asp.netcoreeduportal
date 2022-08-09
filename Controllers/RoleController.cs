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
    public class RoleController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly EducationPortalDBContext _con;
        private readonly ILogger<RoleController> _logger;
        public RoleController(IUser user, ILogger<RoleController> logger, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
     
        {
            _con = con;
            _logger = logger;
            _rolePrivileges = rolePrivileges;
            _user = user;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("Role Index Page Accessed");
                return View();
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }
        public IActionResult SaveUserRole(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                try
                {
                    tblRole objrole = new tblRole();
                    if (string.IsNullOrEmpty(id))
                    {
                        _logger.LogInformation("Role Add Page Accessed");
                    }
                    else
                    {
                        var userID = int.Parse(id);
                        objrole = _user.GetUserRoleDetailByUserID(userID);
                        if (objrole == null)
                        {
                            return RedirectToAction("Index", "Role", new { Msg = "drop" });
                        }
                        _logger.LogInformation("Role Update Page Accessed");
                    }
                    return View(objrole);
                }
                catch
                {
                    return RedirectToAction("Index", "Role", new { Msg = "error" });
                }
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult SaveUserRole(tblRole objtblrole)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            if (objtblrole.RoleId == 0)
            {
                if (_user.IsUserRoleExists(objtblrole.RoleName))
                {
                    TempData["fail"] = "Role Name Already Exist";
                    return View();
                }
                else
                {
                    objtblrole.CreatedBy = HttpContext.Session.GetInt32("uid");
                    _user.AddUserRole(objtblrole);
                    TempData["success"] = "User Role Added Successfully";
                    _logger.LogInformation("Role Added Successfully");
                    return RedirectToAction("Index", "Role");
                }
            }
            var userDetail = _user.GetUserRoleDetailByUserID(objtblrole.RoleId);
            if (userDetail == null)
            {
                return RedirectToAction("Index", "Role");
            }

            if (_user.IsUpdateUserRoleExists(objtblrole.RoleId, objtblrole.RoleName))
            {
                TempData["fail"] = "Role Name Already Exist";
                return View(objtblrole);
            }
            objtblrole.ModifiedBy = HttpContext.Session.GetInt32("uid");
            _user.EditUserRole(objtblrole);
            TempData["success"] = "User Role Updated Successfully";
            _logger.LogInformation("Role Updated Successfully");
            return RedirectToAction("Index", "Role");
        }

      [HttpPost]
        public IActionResult Delete(string[] roleId)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            try
            {
                if (roleId.Length > 0)
                {
                    _user.DeleteRole(roleId);
                    _logger.LogInformation("Role Deleted Successfully");
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

        public IActionResult CategoryList()
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

        public IActionResult UserRoleDetails(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                var record = _con.tblRole.Where(x => x.RoleId == Convert.ToInt32(id)).FirstOrDefault();
                _logger.LogInformation("Role Details Page Accessed");
                return View(record);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult Category(int? id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                tblCategory tblCategory = new tblCategory();
                if (id>0)
                {
                    var record = _con.tblCategory.Find(id);
                    _logger.LogInformation("Category Update Page Accessed");
                    return View(record);
                }
                _logger.LogInformation("Category Add Page Accessed");
                return View(tblCategory);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public IActionResult Category(tblCategory objtbl)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            if (objtbl.CategoryID>0)
            {
                if (_user.IsUserUpdateCategoryExists(objtbl.Name, objtbl.CategoryID))
                {
                    TempData["fail"] = "Category Already Exists";
                    return View();
                }
                objtbl.UpdatedBy = HttpContext.Session.GetInt32("uid");
                objtbl.UpdatedDate = DateTime.Now;
                _con.Entry(objtbl).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _con.SaveChanges();
                TempData["success"] = "Category Updated Successfully!";
                _logger.LogInformation("Category Updated Successfully");
            }
            else
            {
                ViewBag.id = 0;
                if (_user.IsUserCategoryExists(objtbl.Name))
                {
                    TempData["fail"] = "Category Already Exists";
                    return View();
                }
                objtbl.CreatedBy = HttpContext.Session.GetInt32("uid");
                objtbl.CreatedDate = DateTime.Now;
                _con.tblCategory.Add(objtbl);
                _con.SaveChanges();
                TempData["success"] = "Category added Successfully!";
                _logger.LogInformation("Category Added Successfully");
            }
            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        public ActionResult<IList<tblCategory>> _AjaxBindingCategory()
        {
            var userList = _user.BindCategoryDetail().Where(x=>x.IsActive&&!x.IsDeleted).OrderByDescending(c=>c.CategoryID).ToList();
            return Json(userList);
        }
        public ActionResult<IList<tblRole>> _AjaxBinding()
        {
            var userList = _user.BindUserRoleDetail().Where(x=>x.IsActive && !x.IsDeleted).OrderByDescending(c=>c.RoleId).ToList();
            return Json(userList);
        }
    }
}
