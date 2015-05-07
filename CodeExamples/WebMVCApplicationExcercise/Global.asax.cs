using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebMVCApplicationExcercise
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Create Logger
            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.AppSettings()
                    //.WriteTo.Seq("http://localhost:5341")
                    .CreateLogger();

            Log.Information("Start of WebApplicationExercise at {startup}", DateTime.Now);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            // create sticky session id
            Session["init"] = 0;

            // detect platform using System.Web.Mobile.MobileCapabilities
            Log.Information("Session {session} is using {os}", this.Context.Session.SessionID, Context.Request.Browser.Platform);
        }
    }
}
