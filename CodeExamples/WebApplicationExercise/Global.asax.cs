using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplicationExercise
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Create Logger
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.Seq("http://localhost:5341")
                    .CreateLogger();

            Log.Information("Start of WebApplicationExercise at {startup}", DateTime.Now);

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}