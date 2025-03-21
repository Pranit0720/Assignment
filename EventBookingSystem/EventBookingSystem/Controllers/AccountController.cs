using EventBookingSystem.Models;
using EventBookingSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventBookingSystem.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> manager,SignInManager<User> signInManager)
        {
            _userManager = manager;
            _signInManager = signInManager;
            
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
                var createdUser = new User { UserName = user.Email, Email = user.Email ,FirstName=user.FirstName,LastName=user.LastName};
                var result = await _userManager.CreateAsync(createdUser, user.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
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
            if (ModelState.IsValid)
            {
                var result=await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetAllEvents","Event");
                }
                ModelState.AddModelError("", "LoginFailed");
            }
            return View(login);
        }
    }
}
