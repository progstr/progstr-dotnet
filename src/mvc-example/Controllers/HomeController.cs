using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Progstr.Log;
using System.Configuration;
using System.Diagnostics;

namespace Controllers
{

    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {           
            this.Log().Info("Welcome to ASP.NET MVC on Mono!");
            
            var message = "";
            try 
            {
                throw new InvalidOperationException("Oh, noes!");
            }
            catch (Exception error)
            {
                message = error.ToString();
            }
            
            var stopwatch = Stopwatch.StartNew();
            for (var i = 0; i < 2; i++)
            {
                Log.For<HomeController>().Error(message);
            }
            
            stopwatch.Stop();
            
            ViewData["Message"] = "Welcome to ASP.NET MVC on Mono! " + stopwatch.Elapsed.TotalSeconds;
            return View();
        }
    }
}

