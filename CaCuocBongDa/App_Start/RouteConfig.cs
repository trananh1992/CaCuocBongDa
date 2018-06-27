using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaCuocBongDa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Dang Nhap
            routes.MapRoute(name: "Dang-Nhap", url: "dang-nhap", defaults: new { controller = "Account", action = "Login" });
            routes.MapRoute(name: "Dang-Xuat", url: "dang-xuat", defaults: new { controller = "Account", action = "Logout" });
            routes.MapRoute(name: "Dang-Ky", url: "dang-ky", defaults: new { controller = "Account", action = "Register" });
            routes.MapRoute(name: "Lock-Screen", url: "Lock-Screen", defaults: new { controller = "Account", action = "Lock_Screen" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}