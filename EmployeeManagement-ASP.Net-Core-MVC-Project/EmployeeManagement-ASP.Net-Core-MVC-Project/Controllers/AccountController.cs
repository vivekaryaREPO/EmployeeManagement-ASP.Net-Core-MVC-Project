using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement_ASP.Net_Core_MVC_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }




        /*
         * so basically we wanna check if the email exists or not, befor registering
           the user.
         Instead of using both Get and Post, you can use:
         [AcceptVerbs("Get","Post")]

         */ 
        [HttpGet]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user=await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);//no validation error
            }
            else
            {
                return Json($"the email {email} is already in use");
            }
        }









        [HttpPost]
        [AllowAnonymous]
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
                    /*
                     If the user is signed in and in the Admin role, then it is
                    the Admin user that is creating a new user. So redirect the
                    Admin user to ListRoles action
                     */
                    if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }
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
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if(string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("index", "home");
                    }
                    else
                    {
                        /*
                         * we did not want our application to have the open redirect
                           vulnerability, and this is why we used LocalRedirect(returnUrl)
                           and not Redirect(returnUrl).
                         * Or you can also use Url.IsLocalUrl(returnUrl) to check if the Url
                           is local or not, else if url isn't local, exception will be
                           thrown.
                         */
                        return LocalRedirect(returnUrl);
                    }
                    
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }










    }
}
