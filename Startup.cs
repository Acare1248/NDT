using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebNDTIT01.Models;
using WebNDTIT01.Models.Workflows.ITRequestModels;
using WebNDTIT01.Services;
using WebNDTIT01.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebNDTIT01.Workflows.ProcessITRequest;
using WebNDTIT01.Workflows.ProcessITRequest.Steps;
using System.Linq;
using System.Threading;
using WorkflowCore.Interface;


namespace WebNDTIT01
{
    public class Startup
    {
        private IWorkflowHost host;
        //private IWorkflowPurger purge;
         public IConfiguration Configuration { get; }
         public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            LDAPUtil.Register(Configuration);
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ndt_dbContext>();
            services.AddControllersWithViews();

            services.AddDbContext<ndt_dbContext>(
                options => options
                .UseMySql(Configuration.GetConnectionString("DefaultConnection"),serverVersion)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            );
            
           
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(config =>
                {
                    config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                    config.Cookie.MaxAge = config.ExpireTimeSpan;
                    config.SlidingExpiration = true;
                    config.LoginPath = "/Account/Login/"; 
                    config.AccessDeniedPath = "/Account/AccessDenied/"; 
                });

            services.AddLogging();
            //services.AddWorkflow();
            services.AddWorkflow(x => x.UseMySQL(Configuration.GetConnectionString("DefaultConnection"), true, true));

            services.AddTransient<InitialStep>();
            services.AddTransient<IEmailService, EmailService>();            
          
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
             
            host = app.ApplicationServices.GetService<IWorkflowHost>();
            host.RegisterWorkflow<ProcessITRequestWorkflow, ApprovalData>();
            host.Start();

            //Purge workflow from database need a completeTime.
           /* DateTime date1 = new DateTime(2022, 10, 7);
            purge = app.ApplicationServices.GetService<IWorkflowPurger>();
            purge.PurgeWorkflows(WorkflowStatus.Runnable, date1);*/

            //host.Stop();

            //string WorkflowId = host.StartWorkflow("ProcessITRequestWorkflow").Result;

            //var openItems = host.GetOpenUserActions(WorkflowId);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
