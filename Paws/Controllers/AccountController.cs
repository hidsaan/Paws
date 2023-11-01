using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Paws.Models;

namespace Paws.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Signup(User model)
        {
            var user = new IdentityUser { UserName = model.Name, Email = model.Email, PhoneNumber = model.Phone };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var role = await _userManager.AddToRoleAsync(user, "User");

                if (role.Succeeded)
                {
                    return RedirectToAction("IndexPage", "Home");

                }
            }
            return View();
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginUser model)
        {
            var login = await _signInManager.PasswordSignInAsync(model.Email,
                model.Password, false, false);


            if (login != null && login.Succeeded)
            {
                return RedirectToAction("IndexPage", "Home");

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SSignup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SSignup(SuperUser model)
        {
            var user = new IdentityUser { UserName = model.Name, Email = model.Email, PhoneNumber = model.Phone };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var role = await _userManager.AddToRoleAsync(user, "User");

                if (role.Succeeded)
                {
                    return RedirectToAction("IndexPage", "Home");

                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult SLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SLogin(LoginSuperUser model)
        {
            var login = await _signInManager.PasswordSignInAsync(model.Email,
                model.Password, false, false);


            if (login != null && login.Succeeded)
            {
                return RedirectToAction("IndexPage", "Home");

            }
            return View();
        }
    }
}
