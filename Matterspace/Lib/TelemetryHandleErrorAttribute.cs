using Microsoft.ApplicationInsights;
using System;
using System.Web.Mvc;

namespace Matterspace.Lib
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class TelemetryHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext != null && filterContext.HttpContext != null && filterContext.Exception != null)
            {
                var ai = new TelemetryClient();
                ai.TrackException(filterContext.Exception);
            }

            base.OnException(filterContext);
        }
    }
}