using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement_ASP.Net_Core_MVC_Project.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            //if you don't add this mvc dependency, you'll get error as the mvc middleware is 
            //present but it's dependency isn't. So adding this to dependency injection container
            //is mandatory while using the mvc middleware.
            //NOTE: MAKE SURE environment in launchsettings.json is properly set, otherwise the error
            //will not be displayed properly, as app.UseDeveloperExceptionPage() middleware is triggerred
            //only when the env is developemnt. Or change add a middleware for other environments as well.
            //AddMvc internally calls AddMvcCore()

            services.AddDbContextPool<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("EmployeeDbConnection"))
            ) ;//used to register our application db context class, to specify the db we are using
            services.AddMvc().AddXmlSerializerFormatters();
            // services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();

            services.AddScoped<IEmployeeRepository,SQLEmployeeRepository>();//one instance for each request

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //you can also use public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup> logger)
            //i.e inject ILogger to get things log on receiving request or sending response.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //An ApplicationBuilderFactory is used to create an ApplicationBuilder instance. 
            //ApplicationBuilder type implements the IApplicationBuilder interface
            //But IApplicationBuilder doesn have Run() method in it, so it is implemented
            //as an extension method in RunExtensions class-public static void Run(this IApplicationBuilder app, RequestDelegate handler);
            //RequestDelegate is a delegate that represents a function, that accepts HttpContext type parameter (i.e the function below)
            //HttpContext class has a field name Response of type HttpResponse, and this HttpResponse has a method  WriteAsync(string xyz)



            //Use() is present in IApplicationBuilder, it is implemented as an extension method in 
            //UseExtensions class. Use(this IApplicationBuilder app, Func<HttpContext, Func<Task>, Task> middleware)
            //Func<HttpContext, Func<Task>, Task> is  our below method, with context as HttpContext object
            //and next as Func<Task> which represents the app.Run(..) after app.Use(..).
            //Task is a class that has many constructors and functions. next() is a delegate.
            //app.Use(async (context,next) =>
            //{
            //    await context.Response.WriteAsync(config["MyKey"]+" , Hello World!");
            //    await next();
            //});



            //DefaultFilesOptions dfo = new DefaultFilesOptions();
            //dfo.DefaultFileNames.Clear();
            //dfo.DefaultFileNames.Add("foo.html");

            //use UseDefaultFiles before UseStaticFiles(),
            //you can use another overload of UseDefaultFiles(DefaultFilesOptions dfo), if you want 
            //to change the default page from defualt.html/index.html. explained clearly in the docs
            //app.UseDefaultFiles(dfo);


            //app.UseStaticFiles();// serves static files present in wwwroot.

            //Instead of using both UseDefaultFiles() and UseStaticFiles(), you can use
            //UseFileServer(FileServerOptions fso) overload.
            //FileServerOptions fso = new FileServerOptions();
            //fso.DefaultFilesOptions.DefaultFileNames.Clear();
            //fso.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            //app.UseFileServer(fso);


            app.UseStaticFiles();//if request is for static file, this is executed and this middleware short circuits the pipeline.


            //This adds MVC support for our application, i.e what a default route should
            //be. Instead of this you can use app.UsemMvc().This method doesn configure
            //any default route. So you can use another overload of UseMvc that takes instance
            //of Action<IRouteBuilder> and you can use MapRoute() on this instance to configure
            //your routes. Every route you configure must have a name and template. eg.
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
            //default is name of the route, template implies url pattern,? in id means id is optional, controller=home means our default controller is Home
            
            //3rd way to configure routing is through Attribute routing.
            //You can use Route decorator on controller class and controller action method to do that.-see controller action mthod.
            
            app.UseMvcWithDefaultRoute();//if rquest is for static file, this isn't executed. So no unnecessary processing is done.


            //having this commented will not display "Hello world" in the output when a
            //wrong controller and action method is requested, so directly the error is displayed
            //as mvc middleware culdn't find the respective CAM in a respective controller that was
            //requested by the client. If you have this uncommented, then even though the requested CAM 
            //in a respective controller is not found the, the controll request will be passed
            //toRun() middleware and it's output "Hello World!" will be displayed.
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
