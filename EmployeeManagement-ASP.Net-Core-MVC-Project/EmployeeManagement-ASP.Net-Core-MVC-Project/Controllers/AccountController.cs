using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement_ASP.Net_Core_MVC_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser{UserName=model.Email, Email = model.Email};
                var result=await userManager.CreateAsync(user,model.Password);//asynchronous methods needs await
                if(result.Succeeded)//if user is created, sign the user in
                {
                    /*
                     SignInAsync(..) it takes IdentityUser object and type of cookie as parameter
                     -There are 2 types of cookie,
                    1.session cookie: lost after browser is closed.
                    2.Permanent cookie: is retained even after the browser is closed
                     
                     
                     */
                    await signInManager.SignInAsync(user,isPersistent:false);
                    return RedirectToAction("index","home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }



            }
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }













    }
}
