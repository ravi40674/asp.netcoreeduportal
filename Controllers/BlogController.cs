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
    public class BlogController : Controller
    {
        private readonly IUser _user;
        private readonly ILogger<BlogController> _logger;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly ICollege _college;
        private readonly EducationPortalDBContext _con;
        public readonly IWebHostEnvironment _IWebHostEnvironment;
        public BlogController(ICollege college, ILogger<BlogController> logger, IWebHostEnvironment IWebHostEnvironment,IUser user, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _rolePrivileges = rolePrivileges;
            _user = user;
            _college = college;
            _logger = logger;
            _IWebHostEnvironment = IWebHostEnvironment;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid") > 0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("Blog List Page accessed");
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
                    tblBlog objcms = new tblBlog();
                    if (string.IsNullOrEmpty(id))
                    {
                        _logger.LogInformation("Blog Add Page accessed");
                    }
                    else
                    {
                        var cmsID = int.Parse(id);
                        objcms = _college.GetBlogDetailByUserID(cmsID);
                        if (objcms == null)
                        {
                            return RedirectToAction("Index", "Blog", new { Msg = "drop" });
                        }
                        _logger.LogInformation("Blog Update Page accessed");
                    }
                    return View(objcms);
                }
                catch
                {
                    return RedirectToAction("Index", "Blog", new { Msg = "error" });
                }
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult Save(tblBlog objtbl)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            if (objtbl.Description == null)
            {
                ViewBag.blogID = objtbl.BlogID;
                return View(objtbl);
            }
            if (objtbl.BlogID == 0)
            {
                objtbl.CreatedBy = HttpContext.Session.GetInt32("uid");
                objtbl.CreatedDate = DateTime.Now;
                string uploadimage = _college.UploadBlogimage(objtbl);
                if (uploadimage != null)
                {
                    objtbl.Image = uploadimage;
                }
                else
                {
                    TempData["fail"] = "Please Upload .jpg or .jpeg or .png of any one Image file";
                    return View(objtbl);
                }
                _college.AddBlog(objtbl);
                TempData["success"] = "Blog Added Successfully";
                _logger.LogInformation("Blog Added Successfully");
                return RedirectToAction("Index", "Blog");
            }
            var userDetail = _college.GetBlogDetailByUserID(objtbl.BlogID);
            if (userDetail == null)
            {
                return RedirectToAction("Index", "Blog");
            }

            objtbl.UpdatedBy = HttpContext.Session.GetInt32("uid");
            objtbl.UpdatedDate = DateTime.Now;
            string uploadimages = _college.UploadBlogimage(objtbl);
            if (uploadimages == null)
            {
                if (userDetail.Image != null)
                {
                    objtbl.Image = objtbl.Image;
                }
                else
                {
                    TempData["fail"] = "Please Upload .jpg or .jpeg or .png of any one Image file";
                }
            }
            else
            {
                if (objtbl.Image != uploadimages)
                {
                    var imgpath = Path.Combine(_IWebHostEnvironment.WebRootPath, "ApplicationDocument/BlogImages", userDetail.Image);
                    if (System.IO.File.Exists(imgpath))
                    {
                        System.IO.File.Delete(imgpath);
                    }
                }
                objtbl.Image = uploadimages;
            }
            _college.EditBlog(objtbl);
            TempData["success"] = "Blog Updated Successfully";
            _logger.LogInformation("Blog Updated Successfully");
            return RedirectToAction("Index", "Blog");
        }

        [HttpPost]
        public IActionResult Delete(string[] blogID)
        {
            try
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                if (blogID.Length > 0)
                {
                    _college.DeleteBlog(blogID);
                    _logger.LogInformation("Blog Deleted Successfully");
                    return RedirectToAction("Index", "Blog", new { Msg = "deleted" });
                }
                else
                {
                    return RedirectToAction("Index", "Blog", new { Msg = "NoSelect" });
                }
            }
            catch (Exception _exception)
            {
                if (_exception.InnerException != null && (_exception.InnerException.Message.Contains(GlobalCode.foreignKeyReference) || ((_exception.InnerException).InnerException).Message.Contains(GlobalCode.foreignKeyReference)))
                {
                    return RedirectToAction("Index", "Blog", new { Msg = "inuse" });
                }
                return RedirectToAction("Index", "Blog", new { Msg = "error" });
            }
        }

        public IActionResult Details(string id)
        {
            if (HttpContext.Session.GetInt32("uid") > 0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                var record = _con.tblBlog.Where(x => x.BlogID == Convert.ToInt32(id)).FirstOrDefault();
                _logger.LogInformation("Blog Details Page Accessed");
                return View(record);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult<IList<tblBlog>> _AjaxBinding()
        {
            var userList = _college.BindBlog().Where(x=>x.IsActive&&!x.IsDeleted).OrderByDescending(c => c.BlogID).ToList();
            return Json(userList);
        }
    }
}
