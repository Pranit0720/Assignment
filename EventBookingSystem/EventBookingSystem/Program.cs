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
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(); 
            string conn = builder.Configuration.GetConnectionString("LocalString");
            builder.Services.AddDbContext<BookingContext>(options=>options.UseSqlServer(conn));
            builder.Services.AddScoped<IEventRepo,EventRepo>();
            builder.Services.AddScoped<IEventServices, EventServices>();

            builder.Services.AddScoped<ITicketBookingRepo, TicketBookingRepo>();
            builder.Services.AddScoped<ITicketBookingServices, TicketBookingServices>();
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BookingContext>()
                .AddDefaultTokenProviders();//Add and receive info about user using



            builder.Services.AddMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
            });

            var app = builder.Build();

            //Create Roles and Default Admin
            using(var scope = app.Services.CreateScope())
            {
                var service= scope.ServiceProvider;
                 await SeedRoleAndAdmin(service);
            }


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();//Authentication MiddleWare

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Event}/{action=GetAllEventsForUser}/{id?}");

            app.Run();
        }

        private static async Task SeedRoleAndAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            string[] roleNames = { "Admin", "Organizer", "User" };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }

            }

            //  Create Default Admin User
            string adminEmail = "admin@gmail.com";
            string adminPassword = "Admin@123";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var newAdmin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(newAdmin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }


    }
}