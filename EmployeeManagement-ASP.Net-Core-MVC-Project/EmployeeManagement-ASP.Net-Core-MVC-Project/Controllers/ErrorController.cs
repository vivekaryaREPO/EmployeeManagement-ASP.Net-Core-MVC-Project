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

    }
}
