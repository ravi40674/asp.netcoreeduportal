using EducationPortal.Models;
using EducationPortal.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace EducationPortal.Interface
{
    public interface IUser
    {
        IQueryable<tblUser> BindUserDetail();
        List<UserViewModel> GetRoleList(int roleID, string roleName);
        bool IsUserExists(string userID, string emailID);
        void AddUser(UserViewModel objUserViewModel);
        UserViewModel GetUserDetailByUserID(int userID);
        bool IsUserExistsByEmail(string fieldList, string valueList, int strAddOrEditID);
        void EditUser(UserViewModel objUserViewModel);
        void DeleteUser(string[] ids);
        UserViewModel GetActiveUserByEmail(string email);
        bool IsUpdateUserExists(int userID, string mobileNumber, string v);
        IQueryable<tblRole> BindUserRoleDetail();
        tblRole GetUserRoleDetailByUserID(int userID);
        bool IsUserRoleExists(string roleName);
        void AddUserRole(tblRole objtblrole);
        bool IsUpdateUserRoleExists(int roleId, string roleName);
        IQueryable<CourseViewModel> BindCourseDetail();
        void EditUserRole(tblRole objtblrole);
        void DeleteRole(string[] roleId);
        List<tblCourse> CoursesBind();
        IQueryable<tblCategory> BindCategoryDetail();
        void DeleteCategorys(string[] categoryID);
        List<tblCategory> CategoryBind();
        tblCollegeSemester GetCourseSemesterByUserID(int userID);
        bool IsUserCategoryExists(string name);
        bool IsUserUpdateCategoryExists(string name, int categoryID);
        List<tblCourse> CourseBind();
        void DeleteCourses(string[] courseID);
        CourseViewModel GetCourseDetailByUserID(int userID);
        void AddCourse(tblCourse objtblcourse);
        void EditCourse(tblCourse objtblcourse);
        IQueryable<tblNewsLetter> BindDetail();
        void Delete(string[] newsLetterID);
    }
}

