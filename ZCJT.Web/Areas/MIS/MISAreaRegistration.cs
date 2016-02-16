using System.Web.Mvc;

namespace ZCJT.Web.Areas.MIS
{
    public class MISAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MIS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               "MIS_Globalization", // 路由名称
               "{lang}/MIS/{controller}/{action}/{id}", // 带有参数的 URL
               new { lang = "zh", controller = "Account", action = "Index", id = UrlParameter.Optional }, // 参数默认值
               new { lang = "^[a-zA-Z]{2}(-[a-zA-Z]{2})?$" }    //参数约束
           );

            context.MapRoute(
                "MIS_default",
                "MIS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "ZCJT.Web.Areas.MIS.Controllers" }
            );
        }
    }
}
