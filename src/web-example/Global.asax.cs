using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.IO;
using Progstr.Log;
using System.Text.RegularExpressions;

namespace WebExample
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var url = HttpContext.Current.Request.Url;
            var exception = this.Server.GetLastError();
            if (!this.IgnoreError(exception))
            {
                var requestBody = this.ReadRequestBody();

                var message = string.Format("Uncaught exception for URL:{0}\r\nREQUEST:\r\n{1}", url, requestBody);
                this.Log().Error(message, exception);
            }
        }

        /// <summary>
        /// Ignore 404 errors that the ASP.NET MVC controller factory "helpfully"
        /// turns into "Controller not found" errors.
        /// </summary>
        private bool IgnoreError(Exception error)
        {
            var message = error.Message;
            return Regex.IsMatch(message, "The controller for path.*was not found");
        }
        
        private string ReadRequestBody()
        {
            var requestFile = Path.GetTempFileName();
            this.Context.Request.SaveAs(requestFile, true);
            var requestBody = File.ReadAllText(requestFile);
            File.Delete(requestFile);
            return requestBody;
        }
    }
}