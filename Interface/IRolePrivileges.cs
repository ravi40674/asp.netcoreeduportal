using EducationPortal.Models;
using System.Collections.Generic;
using System.Data;

namespace EducationPortal.Interface
{
    public  interface IRolePrivileges
    {
        void DeleteRolePrivilegesByRoleID(int RoleID);
        List<tblRolePrivilege> GetUserSelectList(int? RoleID);
        DataTable ExecuteStoredProcedure(string strSpName, int RoleID);
        IList<tblRolePrivilege> GetMainMenuList(int RoleID, bool isAdminUser);
        IList<tblRolePrivilege> GetMenuList(int RoleID, bool isAdminUser);
        List<tblRolePrivilege> AllroleprevList(int designationID);
    }
}
