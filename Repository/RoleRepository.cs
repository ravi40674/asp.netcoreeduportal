using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using EducationPortal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Repository
{
    public class RoleRepository : IRole
    {
        #region Member Declaration
        private readonly EducationPortalDBContext _context;
        #endregion

        #region Constractor
        public RoleRepository(EducationPortalDBContext context)
        {
            _context = context;
        }
        #endregion

        #region Add Role
        public void SaveChanges(RoleViewModel objRoleViewModel)
        {
            tblRole objTblRole = new tblRole();
            objTblRole.RoleName = objRoleViewModel.Role.Trim();
            _context.tblRole.Add(objTblRole);
            _context.SaveChanges();
        }
        #endregion

        #region Update Role
        public void UpdateRole(RoleViewModel objRoleViewModel)
        {
            var objTblRole = _context.tblRole.Where(r => r.RoleId == objRoleViewModel.RoleId).FirstOrDefault();
            if (objTblRole != null)
            {
                objTblRole.RoleName = objRoleViewModel.Role.Trim();
                _context.SaveChanges();
            }
        }
        #endregion

        #region Bind Role Detail
        public IQueryable<RoleViewModel> BindRoleDetail()
        {
            var RoleDetail = (from r in _context.tblRole
                              orderby r.RoleName
                              select new RoleViewModel
                              {
                                  RoleId = r.RoleId,
                                  Role = r.RoleName,
                              });
            return RoleDetail;
        }
        #endregion

        #region Get Role Detail By Role ID
        #endregion

        #region Delete Role
        public void DeleteRole(string[] ids)
        {
            var IdsToDelete = ids.Select(int.Parse).ToList();
            _context.tblRole.RemoveRange(_context.tblRole.Where(r => IdsToDelete.Contains(r.RoleId)).AsEnumerable());
            _context.SaveChanges();
        }
        #endregion

        #region Is Role Exists
        public bool IsRoleExists(int roleID, string roleName)
        {
            bool result = (from r in _context.tblRole
                           where (roleID == 0 || r.RoleId != roleID)
                           && (string.Equals(r.RoleName.Trim(), roleName, StringComparison.OrdinalIgnoreCase))
                           select r.RoleId).Any();
            return result;
        }
        #endregion

        #region Get Active And Non Admin Role List
        public List<tblRole> GetActiveAndNonAdminRoleList()
        {
            List<tblRole> s = _context.tblRole.Where(x=>!x.IsDeleted&&x.IsActive).ToList();
            return s;
        }
        #endregion
    }
}
