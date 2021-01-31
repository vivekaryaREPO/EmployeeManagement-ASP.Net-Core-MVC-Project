using EmployeeManagement_ASP.Net_Core_MVC_Project.Models;
using EmployeeManagement_ASP.Net_Core_MVC_Project.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.Controllers
{

    //[Route("Home")]//this makes /Home optional on CAM
    //This has a disadvantage, in case you change your controller name later.
    //So you can use token replacement, we use [controller] to put a controller token
    //[Route("[controller]")] , so [controller] is substituted with the controller name
    //that's passed in the request url, in this controller class, it'll be replaced with HomeController or Home
    //You can use [Route("[controller]/[action]")], so that all that [Route("[action]")] will become optional, but
    //then you'll need to always pass action name along with controller name in your every request.
    //So then your root CAM of the application will not work if you don't pass CAM name, so for that you can decorate the root CAM
    //of your application with Route["~/Home"], so this becomes default CAM of HomeController as this is executed if request is for /Home
    public class HomeController:Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment _hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            hostingEnvironment = _hostingEnvironment;
        }


        //[Route("")]//when you navigate to root url, this CAM will be executed i.e default or first CAM executed in the application.
        //[Route("/Home")]//when you navigate to /home,then also this CAM will be executed
        //[Route("/Home/Index")]//when you navigate to /home/index url, then also this CAM will be executed
        //NOTE:MAKE SURE THERE'S NO ROUTE SET ON CONTROLLER CLASS, FOR THIS TO WORK.
        //IF YOU'VE SET ROUTE ON THE CONTROLLER EG. Route("Home"), then you may give the route URL as:
        //[Route("")]:when u navigate to /home, or use [Route("Index")] or both
        //To have Index set as our root CAM when Controller route is set, use: [Route("~/")] this means, that
        //Controller class route value will not be combined with CAM route value.
        //It doesn't matter what the name of CAM is, all matters is Route or attribute configuration we've given.
        //To use token replacement, we can write [Route("[action]")], [action] is substituted with CAM name passed in the request URL.
        //now even if u change CAM name, your request acceptance will not break.

        public ViewResult Index()
        {
            IEnumerable<Employee> employees= _employeeRepository.GetAllEmployees();
            return View(employees);
        }


        //JsonResult return type is fine if we wanna return json for every request.
        // But that's not mandatory when building API as API has standards as here content navigation is absent.
        //To respect content negotitation make return type to ObjectResult.
        //JsonResult class extends ActionResult and implements IActionResult.
        //ViewResult class extends ActionResult and implements IActionResult.

        //[Route("/home/details/{id?}")]// when Controller class Route isn't set
        //when controller class level Route is set, we can write: [Route("/details/{id?}")]
        public ViewResult Details(int? id)
        {

            // return Json(_employeeRepository.GetEmployee(1));
            //return new ObjectResult(_employeeRepository.GetEmployee(1)) when returning 
            //ObjectResult, use xml formatter in AddMvc() in configure() of Startup class
            //to provide support for Xml
            //ObjectResult class too extends ActionResult and implements IActionResult

            //But here, we wanna build mvc web app not web api, so we want view to present the
            //model data to the user, so controller selects the view and passes the model data into it
            //the view then generates html to present the model data and this html is sent to the client
            //over the network.
            //a view is a file with .cshtml extension, if ur using cs as ur language

            //You can use another overload of View wherein you can pass the view name and view file path
            //there are 4 overloads
            //you can pass data to the view in 3 ways, viewbag,viewdata, strongly typed view.
            //view data is dictionary of weakly typed objects.
            //1.ViewData:Its avoided as it doesn provide intellisense,code check before.It is loosely typed.
            //ViewData["Page Title"] = "The Employee Details";
            //ViewData["employee"] = _employeeRepository.GetEmployee(2);

            //2.ViewBag: It's a wrapper around view data. Here we use dynamic properties
            //ViewBag.Employee= _employeeRepository.GetEmployee(4);
            //ViewBag.PageTitle = "Hello from view bag";

            //3. Strongly typed view: It's strongly typed, gives compile time and development time errors.
            //Employee model= _employeeRepository.GetEmployee(4);
            //return View(model);

            //4.View models:in this we place all the data required for in a view, as even a strongly typed
            //view may not have all data needed inside the view.

            Employee employee = _employeeRepository.GetEmployee(id.Value);
            if(employee==null)
            {
                Response.StatusCode = 404;

                return View("EmployeeNotFound", id.Value);
            }
            HomeDetailsViewModel model = new HomeDetailsViewModel()
            {
                PageTitle = "View Model Title Example",
                Employee = employee
            };
            return View(model);
        }

        [HttpGet]//when an employee is to be created i.e the form
        public ViewResult Create()
        {
            return View();
        }


        [HttpPost]//when an employee is submitted
        public IActionResult Create(EmployeeCreateViewModel  employee)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(employee.Photos!=null && employee.Photos.Count>0)
                {
                    //To upload only single file
                    //String uploadsFolder=Path.Combine(hostingEnvironment.WebRootPath, "images");
                    //uniqueFileName=Guid.NewGuid().ToString() + " " + employee.Photo.FileName;
                    //string filePath = Path.Combine(uploadsFolder,uniqueFileName);
                    //employee.Photos.CopyTo(new FileStream(filePath,FileMode.Create));
                    foreach (IFormFile photo in employee.Photos)
                    {
                        //to upload multiple files
                        String uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + " " + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));

                    }

                }
                Employee e = new Employee()
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    Department = employee.Department,
                    PhotoPath = uniqueFileName
                };
                Employee emp = _employeeRepository.Add(e);
                return RedirectToAction("Details", new { id = emp.Id });
            }
           return View();//we are able to return this as both RedirectToAction and ViewResult implement IActionResult
        }


        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath

            };
            return View(employeeEditViewModel);
        }


        [HttpPost]//when an employee is submitted
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                string uniqueFileName = null;
                if(model.Photo!=null)
                {
                    if(model.ExistingPhotoPath!=null)
                    {
                        string filePath=Path.Combine(hostingEnvironment.WebRootPath,"images",model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model, uniqueFileName);
                }
  
                Employee emp = _employeeRepository.Add(employee);
                return RedirectToAction("Details");
            }
            return View();//we are able to return this as both RedirectToAction and ViewResult implement IActionResult
        }


        //56.Important
        private string ProcessUploadedFile(EmployeeCreateViewModel model, string uniqueFileName)
        {
            if (model.Photo != null)
            {

           
                String uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + " " + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using(var fileStream= new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }

                

            }

            return uniqueFileName;
        }
    }
}
