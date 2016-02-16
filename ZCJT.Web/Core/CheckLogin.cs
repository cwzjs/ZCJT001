using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ZCJT.Web.Core
{
    public class CheckLogin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session != null)
            {
                if (filterContext.HttpContext.Session.IsNewSession)
                {
                    var sessionCookie = filterContext.HttpContext.Request.Headers["Cookie"];
                    if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId", StringComparison.OrdinalIgnoreCase) >= 0))
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                            new { Controller = "Account", Action = "Index" }));//这里是跳转到Account下的LogOff,自己定义
                    }
                }
            }
        }
    }
}