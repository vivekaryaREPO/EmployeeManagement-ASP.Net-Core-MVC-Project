using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.Controllers
{
    public class ErrorController:Controller
    {
        public ErrorController()
        {

        }


        [Route("error/{statuscode}")]//{statuscode} receives non success status code
        public IActionResult HttpStatusCodeHandler(int statuscode)
        {
            switch(statuscode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                    break;
            }

            return View();
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            //log exceptions, don't display
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.StackTrace = exceptionDetails.Error.StackTrace;
            return View("Error");
        }


    }
}
