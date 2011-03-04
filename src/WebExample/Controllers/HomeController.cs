using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Progstr;

namespace Controllers
{

    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var message = new LogMessage {
                Source = "Controllers.HomeController",
                Text = "Welcome to ASP.NET MVC on Mono!",
                Level = LogLevel.Info,
                Time = Time.MillisecondNow
            };
            var client = new ProgstrClient("DEMO");
            client.Send(message);
            
            ViewData["Message"] = "Welcome to ASP.NET MVC on Mono!";
            return View();
        }
    }
}

