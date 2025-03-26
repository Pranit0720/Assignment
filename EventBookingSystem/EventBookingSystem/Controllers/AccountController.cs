using EventBookingSystem.Models;
using EventBookingSystem.SessionMethods;
using EventBookingSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<User> manager,SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = manager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.Email,
                    EmailConfirmed = true // Automatically confirm email on registration
                };
                var result=await _userManager.CreateAsync(newUser,user.Password);
                if (result.Succeeded)
                {
                    //assign user
                    await _userManager.AddToRoleAsync(newUser, "User");
                    //await _signInManager.SignInAsync(newUser, isPersistent: false);
                    return  RedirectToAction("Login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(user);
            }
            return View(user);
        }


        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            //var temp = await _signInManager.UserManager.GetUserIdAsync();
            if (ModelState.IsValid)
            {
                var result=await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe,false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(login.Email);

                    // Get user roles
                    var roles = await _userManager.GetRolesAsync(user);
                    var userRole = roles.FirstOrDefault(); // Get first role
                    var userId = await _userManager.GetUserIdAsync(user);

                    // Store user ID and role in session
                    HttpContext.Session.SetString("UserId", user.Id);
                    HttpContext.Session.SetString("UserRole", userRole ?? "");

                    //HttpContext.Session.SetString("UserId",user.Id);
                    //HttpContext.Session.SetString("UserRole",userRole ?? "");

                    HttpContext.Session.SetString("UserFullName", $"{user.FirstName} {user.LastName}");

                    TempData["mess"] = $"Welcome, {user.FirstName} {user.LastName}";

                    //return RedirectToAction("Index","Home");


                    if (userRole == "Admin")
                    {
                        return RedirectToAction("GetAllEvents", "Event");
                    }
                    else
                    {
                        //return RedirectToAction("index", "Home");
                        return RedirectToAction("GetAllEventsForUser", "Event");

                    }
                }
                ModelState.AddModelError("", "LoginFailed");
                ModelState.AddModelError("", "Password Or Email is Wrong ");

            }
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
