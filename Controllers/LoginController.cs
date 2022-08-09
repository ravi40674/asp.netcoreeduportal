using EducationPortal.Common;
using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using EducationPortal.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EducationPortal.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly EducationPortalDBContext _con;
        private readonly ILogger<LoginController> _logger;
        public LoginController(IUser user, ILogger<LoginController> logger, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _logger = logger;
            _rolePrivileges = rolePrivileges;
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserViewModel model)
        {
            try
            {
               var  record = _con.tblUser.Where(x => x.Email == model.Email && x.Password == model.Password&&x.IsActive&&!x.IsDeleted).FirstOrDefault();                             
                if (record != null)
                {
                    HttpContext.Session.SetString("uemail",record.Email);
                    HttpContext.Session.SetInt32("uid",record.UserID);
                    HttpContext.Session.SetInt32("urole", record.RoleID);
                    HttpContext.Session.SetString("uname", record.FirstName + " " + record.LastName);
                    ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", record.RoleID);
                    _logger.LogInformation("Login Successfully");
                    return RedirectToAction("Index","User");
                }
                else
                {
                    ModelState.Clear();
                    ModelState.AddModelError(string.Empty, Messages.WrongEmailPassword);
                    _logger.LogInformation("Login failed");
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["fail"] = ex.Message;
            }
            return View();
        }

        public IActionResult ForgotPassword()
        {
             return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(UserViewModel model)
        {
            if (model.Password != null)
            {
                var record = _con.tblUser.Where(x => x.Email == model.Email).FirstOrDefault();
                if (record != null)
                {
                    record.Password = model.Password;
                    _con.Entry(record).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _con.SaveChanges();
                    TempData["success"] = "Password Changed Successfully!";
                    _logger.LogInformation("Forgot Password Changed Successfully");
                    return View();
                }
                TempData["fail"] = "Email is incorrect";
                return View();
            }
            TempData["fail"] = "Please Enter New Password!";
            return View();
        }
        public ActionResult<IList<tblUser>> _AjaxBinding()
        {
            var userList = _user.BindUserDetail().Where(x=>x.IsActive&&!x.IsDeleted).OrderByDescending(c=>c.UserID).ToList();
            return Json(userList);
        }

        public IActionResult AllUser()
        {
            UserViewModel objUserViewModel = new UserViewModel();
            BindRoleDropDown(objUserViewModel);
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs",Convert.ToInt32(HttpContext.Session.GetInt32("urole")) );
            _logger.LogInformation("User Index Page Accessed");
            return View(objUserViewModel);
        }

        public IActionResult SaveUser(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                try
                {
                    UserViewModel objUserViewModel = new UserViewModel();
                    if (string.IsNullOrEmpty(id))
                    {
                        BindRoleDropDown(objUserViewModel);
                        _logger.LogInformation("User Add Page Accessed");
                        return View(objUserViewModel);
                    }
                    else
                    {
                        var userID = int.Parse(id);
                        objUserViewModel = _user.GetUserDetailByUserID(userID);
                        if (objUserViewModel == null)
                        {
                            return RedirectToAction("Index", "User", new { Msg = "drop" });
                        }
                        if (objUserViewModel.Email == GlobalCode.AdminEmailAddress)
                        {
                            return RedirectToAction("Index", "User", new { Msg = "notauthorized" });
                        }
                        BindRoleDropDown(objUserViewModel);
                        objUserViewModel.Password = objUserViewModel.Password;
                        _logger.LogInformation("User Update Page Accessed");
                        return View(objUserViewModel);
                    }
                }
                catch
                {
                    return RedirectToAction("Index", "User", new { Msg = "error" });
                }
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index","Login");
            }
        }
        [HttpPost]
        public IActionResult SaveUser(UserViewModel objUserViewModel, string userId)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            if (objUserViewModel.UserID==0)
            {
                if (_user.IsUserExists(objUserViewModel.MobileNumber, objUserViewModel.Email.Trim()))
                {
                    TempData["fail"] = "Email and/or Mobile Number Already Exist";
                    BindRoleDropDown(objUserViewModel);
                    return View(objUserViewModel);
                }
                else
                {
                    objUserViewModel.CreatedBy = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
                    _user.AddUser(objUserViewModel);
                    TempData["success"] = "User Added Successfully";
                    BindRoleDropDown(objUserViewModel);
                    _logger.LogInformation("User Added Successfully");
                    return RedirectToAction("Index", "User", new { Msg = "added" });
                }
            }

            var userDetail = _user.GetUserDetailByUserID(objUserViewModel.UserID);
            if (userDetail == null)
            {
                return RedirectToAction("Index", "User", new { Msg = "drop" });
            }
            if (userDetail.Email == GlobalCode.AdminEmailAddress)
            {
                return RedirectToAction("Index", "User", new { Msg = "notauthorized" });
            }

            if (_user.IsUpdateUserExists(objUserViewModel.UserID,objUserViewModel.MobileNumber, objUserViewModel.Email.Trim()))
            {
                TempData["fail"] = "Email and/or Mobile Number Already Exist";
                BindRoleDropDown(objUserViewModel);
                return View(objUserViewModel);
            }
            objUserViewModel.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
            _user.EditUser(objUserViewModel);
            TempData["success"] = "User Updated Successfully";
            _logger.LogInformation("User Updated Succefully");
            return RedirectToAction("Index", "User", new { Msg = "updated" });
        }

        private UserViewModel BindRoleDropDown(UserViewModel objUserViewModel)
        {
            objUserViewModel.SelectRole = new SelectList(_user.GetRoleList(0, string.Empty), "RoleID", "roleneme");
            return objUserViewModel;
       }

        public IActionResult Delete(string[] userID)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            try
            {
                if (userID.Length > 0)
                {
                    _user.DeleteUser(userID);
                    TempData["success"] = "User Deleted Successfully!";
                    _logger.LogInformation("User Deleted");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    return RedirectToAction("Index", "User", new { Msg = "NoSelect" });
                }
            }
            catch (Exception _exception)
            {
                if (_exception.InnerException != null && (_exception.InnerException.Message.Contains(GlobalCode.foreignKeyReference) || ((_exception.InnerException).InnerException).Message.Contains(GlobalCode.foreignKeyReference)))
                {
                    return RedirectToAction("Index", "User", new { Msg = "inuse" });
                }
                return RedirectToAction("Index", "User", new { Msg = "error" });
            }
        }

        public IActionResult ChangePassword()
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                try
                {
                    ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                    var records = _con.tblUser.Where(x => x.Email == HttpContext.Session.GetString("uemail")).FirstOrDefault();
                    UserViewModel objusermodel = new UserViewModel
                    {
                        Email = records.Email,
                        Password = records.Password,
                        UserID = records.UserID
                    };
                    _logger.LogInformation("Change Password Index Page Accessed");
                    return View(objusermodel);
                }
                catch (Exception ex)
                {
                    TempData["fail"] = ex.Message;
                }
                return View();
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public IActionResult ChangePassword(UserViewModel model)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            if (model.ConPassword!=null)
            {
                var record = _con.tblUser.Where(x => x.Password == model.Password).FirstOrDefault();
                if (record != null)
                {
                    record.Password = model.ConPassword;
                    _con.Entry(record).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _con.SaveChanges();
                    TempData["success"] = "Password Changed Successfully!";
                    _logger.LogInformation("Password Changed Successfully");
                    return View();
                }
                TempData["fail"] = "Passeord is incorrect!";
                return View();
            }
            TempData["fail"] = "Please Enter  Password!";
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            _logger.LogInformation("Logout Successfully");
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
