using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Mvc;
using Shopping2023.Data;
using Shopping2023.Helpers;
using Shopping2023.Models;

namespace Shopping2023.Controllers
{
    public class AccountController:Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public AccountController(IUserHelper userHelper, DataContext context)
        {
            _context = context;
            _userHelper = userHelper;
        }


        public  IActionResult NotAuthorized()
        {
            return View();
        }


        [HttpGet]
        public  IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {

                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty,"Email o contraseña incorrectos.");
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {

            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
