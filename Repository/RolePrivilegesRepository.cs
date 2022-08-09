using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EducationPortal.Repository
{
    public class RolePrivilegesRepository : IRolePrivileges
    {
        #region Member Declaration
        private readonly EducationPortalDBContext _con;
        public IConfiguration Configuration { get; }
        #endregion

        #region Constractor
        public RolePrivilegesRepository(EducationPortalDBContext context, IConfiguration configuration)
        {
            _con = context;
            Configuration = configuration;
        }
        #endregion

        #region Delete Role Privileges By Role ID
        public void DeleteRolePrivilegesByRoleID(int RoleID)
        {
            _con.tblRolePrivilege.RemoveRange(_con.tblRolePrivilege.Where(c => c.RoleId == RoleID));
            _con.SaveChanges();
        }
        #endregion

        #region Get User List
        public List<tblRolePrivilege> GetUserSelectList(int? designationID)
        {
            List<tblRolePrivilege> c = _con.tblRolePrivilege.Where(x => x.RoleId == designationID).ToList();
            return c;
        }
        #endregion

        #region Execute Store Procedure
        public DataTable ExecuteStoredProcedure(string strSpName, int RoleID)
        {
            string connectionString = Configuration.GetValue<string>("ConnectionStrings:EducationPortal_Connection");
            MySqlConnection con = null;
            DataTable dt = null;
            using (con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand sqlcmd = new MySqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Connection = con;
                sqlcmd.CommandText = strSpName;
                MySqlDataAdapter sqladp = new MySqlDataAdapter(sqlcmd);
                sqlcmd.Parameters.Add(new MySqlParameter("role_id", RoleID));
                sqlcmd.Prepare();
                dt = new DataTable();
                sqladp.Fill(dt);
            }
            return dt;
        }
        #endregion

        #region Get ParentIDs By Role
        #endregion

        #region Get Main Menu List      
        public IList<tblRolePrivilege> GetMainMenuList(int RoleID, bool isAdminUser)
        {

            List<tblRolePrivilege> objMainMenuFinal = new List<tblRolePrivilege>();
            List<tblRolePrivilege> objMainMenu = new List<tblRolePrivilege>();
            List<tblRolePrivilege> objEmpMenu = new List<tblRolePrivilege>();
            objMainMenu = _con.tblRolePrivilege.Where(p => p.ParentID == 0).OrderBy(p => p.SortOrder).ToList();

            objMainMenuFinal = objMainMenu.Union(objEmpMenu).Distinct().ToList();
            objMainMenu = objMainMenu.Intersect(objEmpMenu).ToList();
            objMainMenu = objMainMenu.Except(objEmpMenu).ToList();
            return objMainMenuFinal;
        }
        #endregion

        #region Get Menu List        
        public IList<tblRolePrivilege> GetMenuList(int RoleID, bool isAdminUser)
        {
            List<tblRolePrivilege> objMenuList = _con.tblRolePrivilege.Where(p => p.View == true && p.ParentID != 0)
                                                .OrderBy(p => p.MenuItem).ThenBy(p => p.ParentID).ThenBy(p => p.SortOrder).ThenBy(p => p.MenuItem).ToList();
            if (!isAdminUser)
            {
                using (EducationPortalDBContext db = new EducationPortalDBContext())
                {
                    List<tblRolePrivilege> objEmployeeMenuList = _con.tblRolePrivilege.Where(p => p.RoleId == RoleID && p.ParentID != 0).OrderBy(p => p.MenuItem).ThenBy(p => p.ParentID).ThenBy(p => p.SortOrder).ThenBy(p => p.MenuItem).ToList();
                    foreach (var item in objEmployeeMenuList)
                    {
                        var menu = objMenuList.Where(p => p.MenuItemID == item.MenuItemID).FirstOrDefault();
                        if (menu != null)
                        {
                            if (item.View)
                                menu.View = item.View;
                            if (item.Add)
                                menu.Add = item.Add;
                            if (item.Edit)
                                menu.Edit = item.Edit;
                            if (item.Detail)
                                menu.Detail = item.Detail;
                            if (item.Delete)
                                menu.Delete = item.Delete;
                        }
                        else
                        {
                            objMenuList.Add(item);
                        }
                    }
                }
            }
            return objMenuList.OrderBy(p => p.SortOrder).ToList();

        }

        public List<tblRolePrivilege> AllroleprevList(int roleid)
        {
            int[] sentIds = _con.tblMenuItem.Select(s => s.MenuItemID).Distinct().ToArray();
            var result = _con.tblRolePrivilege.Where(o => !sentIds.Contains(o.MenuItemID)).ToList();
            for (int i = 0; i < result.Count; i++)
            {
                var netrecord = _con.tblRolePrivilege.Where(x => x.PrivilegeID == result[i].PrivilegeID).FirstOrDefault();
                _con.Entry(netrecord).State = EntityState.Deleted;
                _con.SaveChanges();
            }

            List<tblRolePrivilege> s = (from i in _con.tblRolePrivilege
                                        join o in _con.tblMenuItem on i.MenuItemID equals o.MenuItemID
                                        where i.RoleId == roleid
                                         select new tblRolePrivilege
                                        {
                                            PrivilegeID = i.PrivilegeID,
                                            IsActive = i.IsActive,
                                            RoleId = i.RoleId,
                                            MenuItem = i.MenuItem,
                                            MenuItemController = i.MenuItemController,
                                            MenuItemID = i.MenuItemID,
                                            MenuItemView = i.MenuItemView,
                                            ParentID = i.ParentID,
                                            Add = i.Add,
                                            Delete = i.Delete,
                                            Detail = i.Detail,
                                            Edit = i.Edit,
                                            SortOrder = i.SortOrder,
                                            View = i.View
                                        }).ToList();
            return s;
        }
        #endregion
    }
}
