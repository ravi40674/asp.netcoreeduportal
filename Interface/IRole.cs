using EducationPortal.Models;
using System.Collections.Generic;

namespace EducationPortal.Interface
{
    public interface IRole
    {
        void DeleteRole(string[] ids);
        bool IsRoleExists(int roleID, string roleName);
        List<tblRole> GetActiveAndNonAdminRoleList();
    }
}
