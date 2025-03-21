using EventBookingSystem.DBContext;
using EventBookingSystem.Models;
using EventBookingSystem.Repository;
using EventBookingSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EventBookingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(); 
            string conn = builder.Configuration.GetConnectionString("LocalString");
            builder.Services.AddDbContext<BookingContext>(options=>options.UseSqlServer(conn));
            builder.Services.AddScoped<IEventRepo,EventRepo>();
            builder.Services.AddScoped<IEventServices, EventServices>();
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BookingContext>();//Add and receive info about user using

            //Add password validations

            //builder.Services.AddIdentity<IdentityUser, IdentityRole>(Options => 
            //{
            //    Options.Password.RequiredLength = 8;
            //    Options.Password.RequireNonAlphanumeric = false;
            //    Options.Password.RequireLowercase = true;
            //}
            //)
            //    .AddEntityFrameworkStores<BookingContext>();//Add and receive info about user using

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();//Authentication MiddleWare

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}