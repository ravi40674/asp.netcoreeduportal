using EducationPortal.Context;
using EducationPortal.Interface;
using EducationPortal.Models;
using EducationPortal.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EducationPortal.Repository
{
    public class User : IUser
    {
        #region Member Declaration
        private static EducationPortalDBContext _context;
        public readonly IWebHostEnvironment _IWebHostEnvironment;
        #endregion

        #region Constractor
        public User(EducationPortalDBContext context, IWebHostEnvironment IWebHostEnvironment)
        {
            _context = context;
            _IWebHostEnvironment = IWebHostEnvironment;
        }
        #endregion

        #region Is User Exists
        public bool IsUserExists(string mobilenumber, string emailID)
        {
            var emailrecord = _context.tblUser.Where(x => x.Email == emailID&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            var mobilerecord = _context.tblUser.Where(x => x.MobileNumber == mobilenumber&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            if (emailrecord == null&& mobilerecord==null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Get Role List
        public List<UserViewModel> GetRoleList(int roleID, string roleName)
        {
            List<UserViewModel> RoleList = (from c in _context.tblRole
                                            where (string.IsNullOrEmpty(roleName) || c.RoleName == roleName)
                                            && (roleID == 0 || c.RoleId != roleID)&&!c.IsDeleted&&c.IsActive
                                            select new UserViewModel
                                            {
                                                RoleID = c.RoleId,
                                                roleneme = c.RoleName,
                                            }).ToList();
            return RoleList;
        }
        #endregion

        #region Bind User Detail
        public IQueryable<tblUser> BindUserDetail()
        {
            var UserDetail = _context.tblUser;
            return UserDetail;
        }
        #endregion

        #region Add User
        public void AddUser(UserViewModel objUserViewModel)
        {
            tblUser objTblUser = new tblUser();
            objTblUser.FirstName = objUserViewModel.FirstName.Trim();
            objTblUser.LastName = objUserViewModel.LastName.Trim();
            objTblUser.Email = objUserViewModel.Email;
            objTblUser.RoleID = objUserViewModel.RoleID;
            objTblUser.Password = objUserViewModel.Password;
            objTblUser.Address = objUserViewModel.Address;
            objTblUser.MobileNumber = objUserViewModel.MobileNumber;
            objTblUser.IsActive = objUserViewModel.IsActive;
            objTblUser.CreatedDate = DateTime.Now;
            _context.tblUser.Add(objTblUser);
            _context.SaveChanges();
        }
        #endregion

        #region Edit User
        public void EditUser(UserViewModel objUserViewModel)
        {
            var objTblUser = _context.tblUser.Where(u => u.UserID == objUserViewModel.UserID).FirstOrDefault();
            if (objTblUser != null)
            {
                objTblUser.FirstName = objUserViewModel.FirstName.Trim();
                objTblUser.LastName = objUserViewModel.LastName.Trim();
                objTblUser.Email = objUserViewModel.Email;
                objTblUser.Password = objUserViewModel.Password;
                objTblUser.RoleID = objUserViewModel.RoleID;
                objTblUser.Address = objUserViewModel.Address;
                objTblUser.MobileNumber = objUserViewModel.MobileNumber;
                objTblUser.IsActive = objUserViewModel.IsActive;
                objTblUser.ModifiedDate = DateTime.Now;
                _context.SaveChanges();
            }
        }
        #endregion

        #region Get User Detail By User ID
        public UserViewModel GetUserDetailByUserID(int userId)
        {
            UserViewModel objUserViewModel = (from u in _context.tblUser
                                              where u.UserID == userId
                                              select new UserViewModel
                                              {
                                                  UserID = u.UserID,
                                                  Password = u.Password,
                                                  FirstName = u.FirstName,
                                                  LastName = u.LastName,
                                                  Email = u.Email,
                                                  RoleID=u.RoleID,
                                                  Address=u.Address,
                                                  MobileNumber=u.MobileNumber,
                                                  IsActive=u.IsActive,
                                                  IsDeleted=u.IsDeleted,
                                                  CreatedBy=u.CreatedBy,
                                                  CreatedDate=u.CreatedDate,
                                                  ModifiedBy=u.ModifiedBy,
                                                  ModifiedDate=u.ModifiedDate,
                                              }).FirstOrDefault();
            return objUserViewModel;
        }
        #endregion

        #region Get User Count
        public static int GetUserCount(string userName, string email, int userID)
        {
            return (from p in _context.tblUser
                    where (string.IsNullOrEmpty(email) || p.Email == email)
                    && (userID == 0 || p.UserID != userID)
                    select p.UserID).Count();
        }
        #endregion

        #region Is User Exists By Name or Email
        public bool IsUserExistsByEmail(string fieldList, string valueList, int strAddOrEditID)
        {
            bool IsExists = false;
            string strUserName = string.Empty;
            if (!string.IsNullOrEmpty(fieldList))
            {
                if (strAddOrEditID == -1 && strAddOrEditID != 0)
                {
                    strUserName = User.GetUserCount(string.Empty, valueList.Trim(), 0) == 0 ? null : "1";
                }
                else if (strAddOrEditID != 0)
                {
                    strUserName = User.GetUserCount(string.Empty, valueList.Trim(), strAddOrEditID) == 0 ? null : "1";
                }

                if (!string.IsNullOrEmpty(strUserName))
                {
                    IsExists = true;
                }
            }
            return IsExists;
        }
        #endregion        

        #region Delete User
        public void DeleteUser(string[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                var record = _context.tblUser.Where(x => x.UserID == Convert.ToInt32(ids[i])).FirstOrDefault();
                record.IsDeleted = true;
                _context.Entry(record).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
        #endregion

        #region Get Active User By Email
        public UserViewModel GetActiveUserByEmail(string email)
        {
            var userDetail = (from u in _context.tblUser
                              where u.Email == email /* && u.IsActive*/
                              select new UserViewModel
                              {
                                  UserID = u.UserID,
                                  Password = u.Password,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  Email = u.Email,
                              }).FirstOrDefault();
            return userDetail;
        }

        public bool IsUpdateUserExists(int userID, string mobileNumber, string Email)
        {
            var emailrecord = _context.tblUser.Where(x => x.Email == Email &&x.UserID!=userID&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            var mobilerecord = _context.tblUser.Where(x => x.MobileNumber == mobileNumber&&x.UserID!=userID&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            if (emailrecord == null && mobilerecord == null)
            {
                return false;
            }
            return true;
        }

        public IQueryable<tblRole> BindUserRoleDetail()
        {
            var rolelist = _context.tblRole;
            return rolelist;
        }

        public tblRole GetUserRoleDetailByUserID(int roleid)
        {
            var getbyroleid = _context.tblRole.Where(x => x.RoleId == roleid).AsNoTracking().FirstOrDefault();
            return getbyroleid;
        }

        public bool IsUserRoleExists(string roleName)
        {
            var rolerecord = _context.tblRole.Where(x => x.RoleName == roleName&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            if (rolerecord==null)
            {
                return false;
            }
            return true;
        }

        public void AddUserRole(tblRole objtblrole)
        {
            objtblrole.CreatedDate = DateTime.Now;
            _context.tblRole.Add(objtblrole);
            _context.SaveChanges();
        }

        public bool IsUpdateUserRoleExists(int roleId, string roleName)
        {
            var rolerecord = _context.tblRole.Where(x => x.RoleName == roleName && x.RoleId != roleId&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            if (rolerecord==null)
            {
                return false;
            }
            return true;
        }

        public void EditUserRole(tblRole objtblrole)
        {
            objtblrole.ModifiedDate = DateTime.Now;
            _context.Entry(objtblrole).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }


        public void DeleteRole(string[] roleId)
        {
            for (int i = 0; i < roleId.Length; i++)
            {
                var record = _context.tblRole.Where(x => x.RoleId == Convert.ToInt32(roleId[i])).FirstOrDefault();
                record.IsDeleted = true;
                _context.Entry(record).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public IQueryable<tblCategory> BindCategoryDetail()
        {
            return _context.tblCategory;
        }

        public void DeleteCategorys(string[] categoryID)
        {
                for (int i = 0; i < categoryID.Length; i++)
                {
                    var record = _context.tblCategory.Where(x=>x.CategoryID==Convert.ToInt32(categoryID[i])).FirstOrDefault();
                    record.IsDeleted= true;
                    _context.Entry(record).State = EntityState.Modified;
                    _context.SaveChanges();
                }
        }

        public bool IsUserCategoryExists(string name)
        {
            var record = _context.tblCategory.Where(x => x.Name == name&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            if (record==null)
            {
                return false;
            }
            return true;
        }

        public bool IsUserUpdateCategoryExists(string name, int categoryID)
        {
            var record = _context.tblCategory.Where(x => x.Name == name&&x.CategoryID!=categoryID&&x.IsActive&&!x.IsDeleted).SingleOrDefault();
            if (record == null)
            {
                return false;
            }
            return true;
        }

        public IQueryable<CourseViewModel> BindCourseDetail()
        {
            string[] name = _context.tblCategory.Where(x=>x.IsActive&&!x.IsDeleted).Select(x => x.Name).ToArray();
            var c=from i in _context.tblCourse
                  where i.IsActive&&!i.IsDeleted &&!name.Contains(i.Name)
                  orderby i.CourseID descending 
                  select new CourseViewModel { 
                  imgurl=i.Image,
                  IsActive=i.IsActive,
                  IsDeleted=i.IsDeleted,
                  CategoryID=i.CategoryID,
                  CourseID=i.CourseID,
                  ParentId=i.ParentId,
                  CreatedBy=i.CreatedBy,
                  CreatedDate=i.CreatedDate,
                  DisplayName=i.DisplayName,
                  ModifiedBy=i.ModifiedBy,
                  ModifiedDate=i.ModifiedDate,
                  Name=i.Name
                  };
            return c;
        }

        public void DeleteCourses(string[] courseID)
        {
            for (int i = 0; i < courseID.Length; i++)
            {
                var record = _context.tblCourse.Where(x => x.CourseID == Convert.ToInt32(courseID[i])).FirstOrDefault();
                record.IsDeleted = true;
                var imgpath = Path.Combine(_IWebHostEnvironment.WebRootPath, "ApplicationDocument/CourseImages", record.Image);
                if (System.IO.File.Exists(imgpath))
                {
                    System.IO.File.Delete(imgpath);
                }
                _context.Entry(record).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public CourseViewModel GetCourseDetailByUserID(int userID)
        {
            return (from i in _context.tblCourse
                 where  i.CourseID == userID
                 select new CourseViewModel
                 {
                    imgurl=i.Image,
                    IsActive=i.IsActive,
                    IsDeleted=i.IsDeleted,
                    CategoryID=i.CategoryID,
                    CourseID=i.CourseID,
                    ParentId=i.ParentId,
                    CreatedBy=i.CreatedBy,
                    CreatedDate=i.CreatedDate,
                    DisplayName=i.DisplayName,
                    ModifiedBy=i.ModifiedBy,
                    ModifiedDate=i.ModifiedDate,
                    Name=i.Name,
                 })
                .FirstOrDefault();
        }

        public void AddCourse(tblCourse objtblcourse)
        {
            objtblcourse.CreatedDate = DateTime.Now;
            _context.tblCourse.Add(objtblcourse);
            _context.SaveChanges();
        }

        public void EditCourse(tblCourse objtblcourse)
        {
            objtblcourse.ModifiedDate = DateTime.Now;
            _context.Entry(objtblcourse).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<tblCategory> CategoryBind()
        {
            var list = _context.tblCategory.Where(x => !x.IsDeleted).OrderByDescending(c=>c.CategoryID).ToList();
            return list;
        }


        public List<tblCourse> CourseBind()
        {
            string[] name = _context.tblCategory.Where(x => x.IsActive && !x.IsDeleted).Select(x => x.Name).ToArray();
            var courseList =(from c in _context.tblCourse
                            where  c.IsActive &&!c.IsDeleted&&c.CategoryID>0
                            orderby c.Name
                            select new tblCourse
                            {
                                ParentId=c.CourseID,
                                DisplayName=c.Name+ (!name.Contains(c.Name) ? "("+c.DisplayName+")":"")
                            })
                        .ToList();
            return courseList;
        }

        public List<tblCourse> CoursesBind()
        {
            var courseList = (from c in _context.tblCourse
                              select new tblCourse
                              {
                                  CourseID = c.CourseID,
                                  Name = c.Name
                              })
                  .ToList();
            return courseList;
        }

        public tblCollegeSemester GetCourseSemesterByUserID(int userID)
        {
            var courseSemesterGetById = _context.tblCollegeSemester.Where(x => x.CollegeId == userID).FirstOrDefault();
            return courseSemesterGetById;
        }

        public IQueryable<tblNewsLetter> BindDetail()
        {
            return _context.tblNewsLetter;
        }

        public void Delete(string[] newsLetterID)
        {
            for (int i = 0; i < newsLetterID.Length; i++)
            {
                var record = _context.tblNewsLetter.Where(x => x.NewsLetterID == Convert.ToInt32(newsLetterID[i])).FirstOrDefault();
                record.IsDeleted = true;
                record.IsSubscribed = false;
                _context.Entry(record).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        #endregion
    }
}
