using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement_ASP.Net_Core_MVC_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration _config)
        {
            config = _config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*
            if you don't add this mvc dependency, you'll get error as the mvc middleware is 
            present but it's dependency isn't. So adding this to dependency injection container
            is mandatory while using the mvc middleware.
            NOTE: MAKE SURE environment in launchsettings.json is properly set, otherwise the error
            will not be displayed properly, as app.UseDeveloperExceptionPage() middleware is triggerred
            only when the env is developemnt. Or change add a middleware for other environments as well.
            AddMvc internally calls AddMvcCore()
            */


            /*
             used to register our application db context class, to specify the db we 
             are using             
            */
            services.AddDbContextPool<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("EmployeeDbConnection"))
            ) ;
            services.AddMvc(options=> {
                //assigning authorization globally.
                var policy = new AuthorizationPolicyBuilder().
                                    RequireAuthenticatedUser().
                                    Build();
                options.Filters.Add(new AuthorizeFilter(policy));

            }).AddXmlSerializerFormatters();
            
            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            services.AddScoped<IEmployeeRepository,SQLEmployeeRepository>();//one instance for each request





            //lect 65.
            /*
             IdentityUser class inherits from IdentityUser<string> and IdentityUser<string>
            has many propertirs, like username,email,password etc so .net uses this class
            to create user table in db. Properties here is limited so you can iherit this 
            class and add more columns i.e properties.

            IdentityRole:to manage roles of the user.

            AddEntityFrameworkStores<AppDbContext>(): configure to get user and role from
            underlying db. you can override this in the AddIdentity<..>() also.           
             */
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
            }).AddEntityFrameworkStores<AppDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        /*
        you can also use 
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup> logger)
        i.e inject ILogger to get things log on receiving request or sending response.
        */
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            { 
                //NOTE:THIS IS EXECUTED, IF AND ONLY IF THE ENVIRONMENT IS NOT DEVELOPMENT.
                /*
                 If environment is development, then app.UseDeveloperExceptionPage(); is being used to show
                exceptions. For other environment we use UseExceptionHandler().
                we want error controller to handle unhandled exception(i.e exceptions with no try catch)
                 */
                app.UseExceptionHandler("/Error");


                /*
                if environment is other than development and try to navigate to wrong url
                you'll get to an error page, this page is rarely used as it doesn give
                much info
                    
                app.UseStatusCodePages();
                */

                /*
                here you can specify URL you wanna go to if there is non success status code.
                eg. we wanna go to error controller's method that has same name as the non
                success http status code.
                {0}=> place holder to get proper error status code
                eg. if status code is 404 we got to CAM 404.
                so you can use this logic to write logic of any error status code 
                between 400-500.
                /Error/{0} is the url u get redirected to, which is handled by mvc middleware and we
                are able to see our error page in errorcontroller.
                */
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");

                app.UseStatusCodePagesWithRedirects("/Error/{0}");
                /*
                 You can also use:app.UseStatusCodePagesWithReExecute("");
                Difference between app.UseStatusCodePagesWithReExecute(""); and  app.UseStatusCodePagesWithRedirects("/");
                
                -app.UseStatusCodePagesWithRedirects("/"): returns status code 200 after it
                has redirected the user to the error page. So people don't always prefer it
                
                -app.UseStatusCodePagesWithReExecute(""): This middleware after returning the error page
                replaces success status code with original error status code as the midlleware is
                executed again,So error status code is written unlike UseStatusCodePagesWithRedirects
                that returns 200 ok later.
                This does not redirects, hence the url does not change.
                 */
            }


            /*
            An ApplicationBuilderFactory is used to create an ApplicationBuilder instance. 
            ApplicationBuilder type implements the IApplicationBuilder interface
            But IApplicationBuilder doesn have Run() method in it, so it is implemented
            as an extension method in RunExtensions class-public static void Run(this IApplicationBuilder app, RequestDelegate handler);
            RequestDelegate is a delegate that represents a function, that accepts HttpContext type parameter (i.e the function below)
            HttpContext class has a field name Response of type HttpResponse, and this HttpResponse has a method  WriteAsync(string xyz)

            Use() is present in IApplicationBuilder, it is implemented as an extension method in 
            UseExtensions class. Use(this IApplicationBuilder app, Func<HttpContext, Func<Task>, Task> middleware)
            Func<HttpContext, Func<Task>, Task> is  our below method, with context as HttpContext object
            and next as Func<Task> which represents the app.Run(..) after app.Use(..).
            Task is a class that has many constructors and functions. next() is a delegate.
            
            app.Use(async (context,next) =>
            {
                await context.Response.WriteAsync(config["MyKey"]+" , Hello World!");
                await next();
            });

            */



            /*
            DefaultFilesOptions dfo = new DefaultFilesOptions();
            dfo.DefaultFileNames.Clear();
            dfo.DefaultFileNames.Add("foo.html");

            use UseDefaultFiles before UseStaticFiles(),
            you can use another overload of UseDefaultFiles(DefaultFilesOptions dfo), if you want 
            to change the default page from defualt.html/index.html. explained clearly in the docs
            app.UseDefaultFiles(dfo);

            Instead of using both UseDefaultFiles() and UseStaticFiles(), you can use
            UseFileServer(FileServerOptions fso) overload.
            FileServerOptions fso = new FileServerOptions();
            fso.DefaultFilesOptions.DefaultFileNames.Clear();
            fso.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            app.UseFileServer(fso);
            */
            app.UseStaticFiles();//serves static files present in wwwroot.If request is for static file, this is executed and this middleware short circuits the pipeline.
            
            
            
            /*
             Before serving MVC page, authenticate the user.
            */
            app.UseAuthentication();


            /*             
            -app.UseMvcWithDefaultRoute();//if request is for static file, 
            this isn't executed. So no unnecessary processing is done.
            This adds MVC support for our application, i.e what a default route should
            be. 
            
            -Instead of this you can use app.UsemMvc().This method does'nt configure
            any default route. So you can use another overload of UseMvc that takes instance
            of Action<IRouteBuilder> and you can use MapRoute() on this instance to configure
            your routes. Every route you configure must have a name and template. 

            default keyword is name of the route, template implies url pattern,? in id means 
            id is optional, controller=home means our default controller is Home

            -3rd way to configure routing is through Attribute routing.
            You can use Route decorator on controller class and controller action method to do 
            that.-see controller action method.

            eg.
            */
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });






            /*
            having this commented will not display "Hello world" in the output when a
            wrong controller and action method is requested, so directly the error is displayed
            as mvc middleware couldn't find the respective CAM in a respective controller that was
            requested by the client. If you have this uncommented, then even though the requested CAM 
            in a respective controller is not found the, the request will be passed
            to Run() middleware and it's output "Hello World!" will be displayed.

             app.Run(async (context) =>
            {
               await context.Response.WriteAsync("Hello World!");
            });

            */

        }
    }
}
