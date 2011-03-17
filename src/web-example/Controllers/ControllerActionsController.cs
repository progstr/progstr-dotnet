using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Progstr.Log;

namespace WebExample.Controllers
{
    public class ControllerActionsController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Logging controller actions.";
            return View();
        }

        public ActionResult DepositMoney()
        {
            ViewData["Message"] = "Money successfully deposited.";
            return View("Index");
        }

        protected override void OnActionExecuting(ActionExecutingContext executingContext)
        {
            var controller = executingContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = executingContext.ActionDescriptor.ActionName;
            this.Log().InfoFormat("Executing action '{0}' of controller '{1}'", action, controller);
        }

        protected override void OnActionExecuted(ActionExecutedContext executedContext)
        {
            var controller = executedContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = executedContext.ActionDescriptor.ActionName;
            this.Log().InfoFormat("Executed action '{0}' of controller '{1}'", action, controller);
        }
    }
}
