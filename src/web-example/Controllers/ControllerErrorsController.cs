using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Progstr.Log;

namespace WebExample.Controllers
{
    public class ControllerErrorsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Throw()
        {
            throw new InvalidOperationException("Test error triggered by the Progstr.Log samples.");
        }

        protected override void OnException(ExceptionContext exceptionContext)
        {
            var error = exceptionContext.Exception;
            this.Log().Error("Unhandled exception while executing controller.", error);

            //Mark the error as handled and redirect to the default view.
            exceptionContext.ExceptionHandled = true;
            exceptionContext.Result = View("Index");

            ViewData["Message"] = "An error occurred: " + error.Message;
        }
    }
}
