using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Progstr.Log;
using System.Configuration;

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
            var client = new ProgstrClient(ConfigurationManager.AppSettings["progstr.api.token"]);
            client.Send(message);
            
            try 
            {
                throw new InvalidOperationException("Oh, noes!");
            }
            catch (Exception error)
            {
                message.Text = error.ToString();
                message.Level = LogLevel.Error;
            }
            
            message.Time = Time.MillisecondNow;
            client.Send(message);
            
            ViewData["Message"] = "Welcome to ASP.NET MVC on Mono!";
            return View();
        }
    }
}

