using IdentityServer4.Services;
using MeetUp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeetUp.Identity.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IIdentityServerInteractionService interactionService;

        public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IIdentityServerInteractionService interactionService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.interactionService = interactionService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginModel = new LoginModel
            {
            };
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return View(loginModel); 

            var user = await userManager.FindByNameAsync(loginModel.Username);
            
            if (user == null)
            {
                ModelState.AddModelError(String.Empty, "User not found");
                return View(loginModel);
            }

            var result = await signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, false, false);
            if (result.Succeeded)
                return Redirect("/");

            ModelState.AddModelError(String.Empty, "Login error");
            return View(loginModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var registerModel = new RegisterModel
            {
                
            };
            return View(registerModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
                return View(registerModel);

            var user = new AppUser
            {
                FirstName = registerModel.Firstname,
                LastName = registerModel.Lastname,
                UserName = registerModel.Username
            };
            var result = await userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return Redirect("/");
            }

            ModelState.AddModelError(String.Empty, "Login error");
            return View(registerModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await signInManager.SignOutAsync();
            var logoutReq =  await interactionService.GetLogoutContextAsync(logoutId);
            return Redirect(logoutReq.PostLogoutRedirectUri);
        }
    }
}
