using EducationPortal.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EducationPortal.Helpers
{
    public class ValidateUserLogin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CurrentAdminSession.UserID < 0)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.Clear();
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.HttpContext.Response.CompleteAsync();
                    filterContext.Result = new JsonResult(new { Data = "Unauthorize" });
                    return;
                }

                filterContext.HttpContext.Session.Clear();
                foreach (var cookieKey in filterContext.HttpContext.Request.Cookies.Keys)
                {
                    filterContext.HttpContext.Response.Cookies.Delete(cookieKey);
                }
                try
                {
                    var controllerName = ((ControllerBase)filterContext.Controller).ControllerContext.ActionDescriptor.ControllerName;
                    var actionName = ((ControllerBase)filterContext.Controller).ControllerContext.ActionDescriptor.ActionName;
                    filterContext.Result = new RedirectResult("~/Home/Index?Msg=UnAuthorised&ReturnPath=" + controllerName + "/" + actionName);
                }
                catch (Exception)
                {
                    filterContext.Result = new RedirectResult("~/Home/Index?Msg=UnAuthorised");
                }
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public static class HttpRequestExtensions
    {
        private const string RequestedWithHeader = "X-Requested-With";
        private const string XmlHttpRequest = "XMLHttpRequest";

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Headers != null)
            {
                return request.Headers[RequestedWithHeader] == XmlHttpRequest;
            }

            return false;
        }
    }

    public class ValidateUserPermission : ActionFilterAttribute
    {
        GlobalCode.Actions act;

        public ValidateUserPermission(GlobalCode.Actions Action)
        {
            act = Action;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isAuthorize = true;
            if (act == GlobalCode.Actions.Index && !CurrentAdminSession.HasViewPermission)
            {
                isAuthorize = false;
            }

            if (act == GlobalCode.Actions.Create && !CurrentAdminSession.HasAddPermission)
            {
                isAuthorize = false;
            }

            if (act == GlobalCode.Actions.Edit && !CurrentAdminSession.HasEditPermission)
            {
                isAuthorize = false;
            }

            if (act == GlobalCode.Actions.Delete && !CurrentAdminSession.HasDeletePermission)
            {
                isAuthorize = false;
            }

            if (act == GlobalCode.Actions.Detail && !CurrentAdminSession.HasDetailPermission)
            {
                isAuthorize = false;
            }

            if (!isAuthorize)
            {
                filterContext.Result = new RedirectResult("~/Home/Index?Msg=UnAuthorised");
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
