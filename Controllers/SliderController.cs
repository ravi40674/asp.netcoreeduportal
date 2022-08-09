using EducationPortal.Common;
using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using EducationPortal.ViewModel;
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
    public class SliderController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly ICollege _college;
        private readonly ISlider _slider;
        private readonly EducationPortalDBContext _con;
        public readonly IWebHostEnvironment _IWebHostEnvironment;
        private readonly ILogger<SliderController> _logger;
        public SliderController(IWebHostEnvironment IWebHostEnvironment, ILogger<SliderController> logger, ISlider slider, ICollege college, IUser user, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _rolePrivileges = rolePrivileges;
            _user = user;
            _logger = logger;
            _college = college;
            _slider = slider;
            _IWebHostEnvironment = IWebHostEnvironment;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("Slider Index Page Accessed");
                return View();
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult<IList<SliderViewModel>> _AjaxBindingSlider()
        {
            var list = _slider.SliderListBind().Where(x => x.IsActive && !x.IsDeleted).ToList();
            return Json(list);
        }

        public IActionResult SliderDetails(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                tblSlider sliderDetails = _con.tblSlider.Where(x => x.SliderID == Convert.ToInt32(id)).FirstOrDefault();
                _logger.LogInformation("Slider Details Page Accessed");
                return View(sliderDetails);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult SaveSlider(string id)
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                try
                {
                    SliderViewModel objslider = new SliderViewModel();
                    var sliderID = int.Parse(id);
                    objslider = _slider.GetSliderDetailBySliderID(sliderID);
                    if (objslider == null)
                    {
                        return RedirectToAction("Index", "Slider", new { Msg = "drop" });
                    }
                    _logger.LogInformation("Slider Update Page Accessed");
                    return View(objslider);
                }
                catch
                {
                    return RedirectToAction("Index", "Slider", new { Msg = "error" });
                }
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult SaveSlider(SliderViewModel model)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            tblSlider objtblslider = new tblSlider();
                SliderViewModel userDetail = new SliderViewModel();
                if (model.Image != null)
                {
                    userDetail = _slider.PostSliderDetailBySliderID(model.SliderID, model.Image.FileName);
                }
                else
                {
                    userDetail = _slider.PostSliderDetailBySliderID(model.SliderID, model.imgurl);
                }
                if (userDetail == null)
                {
                    return RedirectToAction("Index", "Slider");
                }

                if (_slider.IsUpdatePageExists(model.PageName, model.SliderID))
                {
                    TempData["fail"] = "Page Name Already Exist";
                    return View(userDetail);
                }
                model.ModifiedBy = Convert.ToInt32(HttpContext.Session.GetInt32("uid"));
                objtblslider.ModifiedBy = model.ModifiedBy;
                objtblslider.ModifiedDate = DateTime.Now;
                objtblslider.IsActive = model.IsActive;
                objtblslider.PageName = model.PageName;
                objtblslider.Description = model.Description;
                objtblslider.SortOrder = model.SortOrder;
                objtblslider.IsDeleted = model.IsDeleted;
                objtblslider.Title = model.Title;
                objtblslider.SliderID = model.SliderID;
                string uploadimage = _slider.Uploadimage(model);
                if (uploadimage == null)
                {
                    if (userDetail.imgurl != null)
                    {
                        objtblslider.Image = model.imgurl;
                    }
                    else
                    {
                        TempData["fail"] = "Please Upload .jpg or .jpeg or .png of any one Image file";
                    }
                }
                else
                {
                    if (userDetail.imgurl!=uploadimage)
                    {
                        var imgpath = Path.Combine(_IWebHostEnvironment.WebRootPath, "Images", userDetail.imgurl);
                        if (System.IO.File.Exists(imgpath))
                        {
                            System.IO.File.Delete(imgpath);
                        }
                    }
                    objtblslider.Image = uploadimage;
                }
            _con.Entry(objtblslider).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _con.SaveChanges();
            TempData["success"] = "Slider Updated Successfully";
            _logger.LogInformation("Slider Updated Successfully");
            return RedirectToAction("Index", "Slider");
        }
    }
}
