using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AngularMVCRoomBooking
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute("Api Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}
