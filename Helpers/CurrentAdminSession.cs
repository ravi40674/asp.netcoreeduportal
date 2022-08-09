using Microsoft.AspNetCore.Http;
using System;

namespace EducationPortal.Helpers
{
    public class CurrentAdminSession
    {
        private static HttpContextAccessor _HttpContextAccessor = new HttpContextAccessor();

        public static CurrentAdminUser User
        {
            get
            {
                CurrentAdminUser User = _HttpContextAccessor.HttpContext.Session.GetObject<CurrentAdminUser>("CurrentAdminUser");
                return User;
            }
            set
            {
                _HttpContextAccessor.HttpContext.Session.SetObject("CurrentAdminUser", value);
            }
        }

        public static CurrentAdminPermission Permission
        {
            get
            {
                CurrentAdminPermission Permission = _HttpContextAccessor.HttpContext.Session.GetObject<CurrentAdminPermission>("CurrentAdminPermission");
                return Permission;
            }
            set
            {
                _HttpContextAccessor.HttpContext.Session.SetObject("CurrentAdminPermission", value);
            }
        }

        public static int UserID
        {
            get
            {
                if (User != null)
                    return User.UserID;
                else
                    return -1;
            }
        }

        public static int RoleID
        {
            get
            {
                if (User != null)
                    return User.RoleID;
                else
                    return -1;
            }
        }

        public static string FirstName
        {
            get
            {
                if (User != null)
                    return User.FirstName;
                else
                    return string.Empty;
            }
        }

        public static string LastName
        {
            get
            {
                if (User != null)
                    return User.LastName;
                else
                    return string.Empty;
            }
        }

        public static string UserName
        {
            get
            {
                if (User != null)
                    return User.UserName;
                else
                    return string.Empty;
            }
        }

        public static string Email
        {
            get
            {
                if (User != null)
                    return User.Email;
                else
                    return string.Empty;
            }
        }

        public static bool IsAdminRole
        {
            get
            {
                if (User != null)
                    return User.IsAdminRole;
                else
                    return false;
            }
        }

        public static bool HasViewPermission
        {
            get
            {
                if (User != null)
                    return Permission.HasViewPermission;
                else
                    return false;
            }
        }

        public static bool HasAddPermission
        {
            get
            {
                if (User != null)
                    return Permission.HasAddPermission;
                else
                    return false;
            }
        }

        public static bool HasEditPermission
        {
            get
            {
                if (User != null)
                    return Permission.HasEditPermission;
                else
                    return false;
            }
        }

        public static bool HasDeletePermission
        {
            get
            {
                if (User != null)
                    return Permission.HasDeletePermission;
                else
                    return false;
            }
        }

        public static bool HasDetailPermission
        {
            get
            {
                if (User != null)
                    return Permission.HasDetailPermission;
                else
                    return false;
            }
        }
    }

    [Serializable]
    public class CurrentAdminUser
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public bool IsAdminRole { get; set; }
    }

    [Serializable]
    public class CurrentAdminPermission
    {
        public bool HasViewPermission { get; set; }
        public bool HasAddPermission { get; set; }
        public bool HasEditPermission { get; set; }
        public bool HasDeletePermission { get; set; }
        public bool HasDetailPermission { get; set; }
    }
}
