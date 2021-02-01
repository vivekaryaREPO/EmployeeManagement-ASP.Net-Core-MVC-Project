using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.Controllers
{
    public class ErrorController:Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }


        [Route("error/{statuscode}")]//{statuscode} receives non success status code
        public IActionResult HttpStatusCodeHandler(int statuscode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch(statuscode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                    logger.LogWarning($"Error 404 occured at path: {statusCodeResult.OriginalPath}" +
                        $"and query string {statusCodeResult.OriginalQueryString}");
                    break;
            }

            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            //log exceptions, don't display
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            logger.LogError($"Error occured at path: {exceptionDetails.Path}" +
                        $"threw an exception {exceptionDetails.Error}");

            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.StackTrace = exceptionDetails.Error.StackTrace;
            return View("Error");
        }


    }
}
