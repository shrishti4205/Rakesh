using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace UserManagement.Filters
{
    public class LoggerAttribute : ActionFilterAttribute
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger("UserManagementLogger");
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _log.Info(string.Format("Action Method {0} executing at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()));
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _log.Info(string.Format("Action Method {0} executing at {1}", actionExecutedContext.ActionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()));     
        }

     

    }
}