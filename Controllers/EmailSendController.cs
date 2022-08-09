using EducationPortal.Common;
using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace EducationPortal.Controllers
{
    public class EmailSendController : Controller
    {
        private readonly IUser _user;
        private readonly IRolePrivileges _rolePrivileges;
        private readonly ICollege _college;
        private readonly EducationPortalDBContext _con;
        private readonly IConfiguration _myConfiguration;
        private readonly ILogger<EmailSendController> _logger;
        public EmailSendController(ICollege college, ILogger<EmailSendController> logger, IConfiguration myConfiguration, IUser user, IRolePrivileges rolePrivileges, EducationPortalDBContext con)
        {
            _con = con;
            _logger = logger;
            _rolePrivileges = rolePrivileges;
            _user = user;
            _college = college;
            _myConfiguration = myConfiguration;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid") > 0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                _logger.LogInformation("Email Send History Index Page Accessed");
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
                ViewBag.Template = new SelectList(_con.tblTemplate.Where(x=>x.IsActive&&!x.IsDeleted).ToList(), "TemplateID", "Name");
                try
                {
                    tblEmailSendHistory objemailsend = new tblEmailSendHistory();
                    _logger.LogInformation("Email Send History Add Page Accessed");
                    return View(objemailsend);
                }
                catch
                {
                    return RedirectToAction("Index", "EmailSend", new { Msg = "error" });
                }
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult Save(tblEmailSendHistory objtbl)
        {
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            ViewBag.Template = new SelectList(_con.tblTemplate.Where(x => x.IsActive && !x.IsDeleted).ToList(), "TemplateID", "Name");
            string Email = _myConfiguration.GetValue<string>("CommonSettings:Email");
            string Password = _myConfiguration.GetValue<string>("CommonSettings:Password");
            var record = _con.tblTemplate.Where(x => x.IsActive && !x.IsDeleted && x.TemplateID == Convert.ToInt32(objtbl.TemplateID)).FirstOrDefault();
            objtbl.NewsLetterList = _con.tblNewsLetter.Where(x => x.IsSubscribed && !x.IsDeleted).ToList();
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    foreach (var item in objtbl.NewsLetterList)
                    {
                        mail.From = new MailAddress(Email);
                        mail.To.Add(item.Email);
                        mail.IsBodyHtml = true;
                        mail.Subject = record.Subject;
                        mail.Body = record.Description;
                        //mail.Priority = MailPriority.High;
                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.Credentials = new System.Net.NetworkCredential(Email, Password);
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["fail"] = ex.Message;
                return View(objtbl);
            }
            _college.AddEmailSend(objtbl);
            TempData["success"] = "Email Send Successfully";
            _logger.LogInformation("Email Send History Added Successfully");
            return RedirectToAction("Index", "EmailSend");
        }

        [HttpPost]
        public IActionResult Delete(string[] EmailSendHistoryID)
        {
            try
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                if (EmailSendHistoryID.Length > 0)
                {
                    _college.DeleteEmailSend(EmailSendHistoryID);
                    return RedirectToAction("Index", "EmailSend", new { Msg = "deleted" });
                }
                else
                {
                    return RedirectToAction("Index", "EmailSend", new { Msg = "NoSelect" });
                }
            }
            catch (Exception _exception)
            {
                if (_exception.InnerException != null && (_exception.InnerException.Message.Contains(GlobalCode.foreignKeyReference) || ((_exception.InnerException).InnerException).Message.Contains(GlobalCode.foreignKeyReference)))
                {
                    return RedirectToAction("Index", "EmailSend", new { Msg = "inuse" });
                }
                return RedirectToAction("Index", "EmailSend", new { Msg = "error" });
            }
        }

        public IActionResult Details(string id)
        {
            if (HttpContext.Session.GetInt32("uid") > 0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                var record = _con.tblEmailSendHistory.Where(x => x.EmailSendHistoryID == Convert.ToInt32(id)).FirstOrDefault();
                _logger.LogInformation("Email Send History Details Page Accessed");
                return View(record);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult<IList<tblEmailSendHistory>> _AjaxBinding()
        {
            var userList = _college.BindEmailSend().Where(x => x.IsEmailSend).OrderByDescending(c => c.EmailSendHistoryID).ToList();
            return Json(userList);
        }
    }
}
