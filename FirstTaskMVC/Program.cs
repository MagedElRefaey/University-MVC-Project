using FirstTaskMVC.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FirstTaskMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<NewDepartmentService, DepartmentService>();
            //builder.Services.AddScoped<NewDepartmentService, DepartmentServiceUpgrades>();
            //builder.Services.AddSingleton<NewDepartmentService, DepartmentServiceUpgrades>();
            //builder.Services.AddTransient<NewDepartmentService, DepartmentServiceUpgrades>();
            //builder.Services.AddTransient<NewDepartmentService, DepartmentServiceUpgrades>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddAuthentication();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(a =>
                {
                    a.LoginPath = "/Account/Login";
                });
            var app = builder.Build();

            //Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.Use(async(Context,next)=>
            ////app.Run(async Context =>
            //{
            //    await Context.Response.WriteAsync("Hi\n");
            //    await next();
            //    await Context.Response.WriteAsync("MiddleWhere 2 is excuted and this is MiddleWhere 1\n");
            //});



            //app.Run(async Context =>
            //{
            //    await Context.Response.WriteAsync("Hi Again\n");

            //});

            ////app.Use(async (Context, next) =>
            ////{
            ////    await Context.Response.WriteAsync("Hi Again\n");
            ////    await next();
            ////});

            //app.Use(async (Context, next) =>
            ////app.Run(async Context =>
            //{
            //    await Context.Response.WriteAsync("Hi MiddleWhere3\n");
            //    await next();
            //    await Context.Response.WriteAsync("MiddleWhere 2 in httpcontext is excuted and this is MiddleWhere 3\n");
            //});


            app.Run();
        }
    }
}
