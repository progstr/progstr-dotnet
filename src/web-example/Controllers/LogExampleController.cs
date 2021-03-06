﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Progstr.Log;
using System.Diagnostics;

namespace WebExample.Controllers
{
    [HandleError]
    public class LogExampleController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "MVC severity levels example.";
            return View();
        }
        
        public ActionResult Log(string logMessage, string severity)
        {
            switch (severity)
            {
                case "Info": 
                    this.Log().Info(logMessage);
                    break;
                case "Warning": 
                    this.Log().Warning(logMessage);
                    break;
                case "Error": 
                    this.Log().Error(logMessage);
                    break;
                case "Fatal": 
                    this.Log().Fatal(logMessage);
                    break;
                default:
                    this.Log().Info(logMessage);
                    break;
            }
            
            ViewData[severity ?? "Info"] = true;
            ViewData["Message"] = "Log sent to server.";
            return View("Index");
        }
    }
}
