using System.Web.Mvc;

namespace Cbd.Fgw.Web.Areas.System
{
    public class SystemAreaRegistration : AreaRegistration 
    {
        //系统管理域，授权超级管理员
        public override string AreaName => "System";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "System_default",
                "System/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}