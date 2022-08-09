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
using System.Linq;

namespace EducationPortal.Controllers
{
    public class RolePrivilegeController : Controller
    {
        private readonly ILogger<RolePrivilegeController> _logger;
        private readonly EducationPortalDBContext _con;
        private readonly IRole _role;
        private readonly IRolePrivileges _rolePrivileges;
        public RolePrivilegeController(IRole role, IRolePrivileges rolePrivileges, ILogger<RolePrivilegeController> logger, EducationPortalDBContext con)
        {
            _logger = logger;
            _con = con;
            _role = role;
            _rolePrivileges = rolePrivileges;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("uid")>0)
            {
                ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
                RolePrivilegesViewModel objValidateRolePrivileges = new RolePrivilegesViewModel();
                objValidateRolePrivileges.ModuleName = "Role privileges";
                ViewBag.Designation = new SelectList(_role.GetActiveAndNonAdminRoleList(), "RoleId", "RoleName");
                _logger.LogInformation("Role Priviledge Index Page Accessed");
                return View(objValidateRolePrivileges);
            }
            else
            {
                TempData["fail"] = Messages.Error;
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public IActionResult Index(RolePrivilegesViewModel v, string btnSubmit)
        {
            v.ModuleName = "Role Privileges";
            ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", Convert.ToInt32(HttpContext.Session.GetInt32("urole")));
            ViewBag.Designation = new SelectList(_role.GetActiveAndNonAdminRoleList(), "RoleId", "RoleName");
            if (btnSubmit == null)
            {
                try
                {
                    ViewData["RolePrivileges"] = _rolePrivileges.ExecuteStoredProcedure("RolePrevs", v.RoleId);
                }
                catch (Exception ex)
                {
                    TempData["Fail"] = ex.Message;
                }
                return View(v);
            }
            else if (v.RoleId > 0)
            {
                string strChkView = Request.Form["chkView"];
                string[] strChkViewArray = null;
                if (strChkView != null)
                    strChkViewArray = strChkView.Split(',');

                string strChkAdd = Request.Form["chkAdd"];
                string[] strChkAddArray = null;
                if (strChkAdd != null)
                    strChkAddArray = strChkAdd.Split(',');

                string strChkEdit = Request.Form["chkEdit"];
                string[] strChkEditArray = null;
                if (strChkEdit != null)
                    strChkEditArray = strChkEdit.Split(',');

                string strChkDelete = Request.Form["chkDelete"];
                string[] strChkDeleteArray = null;
                if (strChkDelete != null)
                    strChkDeleteArray = strChkDelete.Split(',');

                string strChkDetail = Request.Form["chkDetail"];
                string[] strChkDetailArray = null;
                if (strChkDetail != null)
                    strChkDetailArray = strChkDetail.Split(',');
                string strparent = Request.Form["hdParentID"];
                string[] strparentarray = strparent.Split(',');
                string strsorder = Request.Form["hdsortorder"];
                string[] strsorderarray = strsorder.Split(',');

                List<tblRolePrivilege> alldata = _rolePrivileges.AllroleprevList(v.RoleId);
                int i = 0;
                foreach (var item in alldata)
                {
                    bool isView = false;
                    bool isAdd = false;
                    bool isEdit = false;
                    bool isDelete = false;
                    bool isDetail = false;

                    if (strChkViewArray != null && strChkViewArray.Contains("v" + item.MenuItemID))
                        isView = true;
                    if (strChkAddArray != null && strChkAddArray.Contains("a" + item.MenuItemID))
                        isAdd = true;
                    if (strChkEditArray != null && strChkEditArray.Contains("e" + item.MenuItemID))
                        isEdit = true;
                    if (strChkDeleteArray != null && strChkDeleteArray.Contains("d" + item.MenuItemID))
                        isDelete = true;
                    if (strChkDetailArray != null && strChkDetailArray.Contains("de" + item.MenuItemID))
                        isDetail = true;

                    tblRolePrivilege objTblRolePrivileges = new tblRolePrivilege();
                    objTblRolePrivileges.RoleId = v.RoleId;
                    objTblRolePrivileges.MenuItem = item.MenuItem;
                    objTblRolePrivileges.MenuItemController = item.MenuItemController;
                    objTblRolePrivileges.MenuItemView = item.MenuItemView;
                    objTblRolePrivileges.ParentID = Convert.ToInt32(strparentarray[i]);
                    objTblRolePrivileges.SortOrder = Convert.ToInt32(strsorderarray[i]);
                    objTblRolePrivileges.View = isView;
                    objTblRolePrivileges.Add = isAdd;
                    objTblRolePrivileges.Edit = isEdit;
                    objTblRolePrivileges.Delete = isDelete;
                    objTblRolePrivileges.Detail = isDetail;
                    objTblRolePrivileges.IsActive = true;
                    objTblRolePrivileges.MenuItemID = item.MenuItemID;
                    objTblRolePrivileges.PrivilegeID = item.PrivilegeID;
                    _con.Entry(objTblRolePrivileges).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _con.SaveChanges();
                    i++;
                }
                TempData["Success"] = "Rights Saved Successfully!";
                _logger.LogInformation("Role Priviledge Rights Saved Successfully");
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["MenuItem"] = null;
                return RedirectToAction("Index", "RolePrivilege");
            }
        }
    }
}
