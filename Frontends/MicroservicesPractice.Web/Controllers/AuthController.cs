using MicroservicesPractice.Web.Models;
using MicroservicesPractice.Web.Services.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesPractice.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInInput signInInput)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = await _identityService.SignIn(signInInput);

            if (!response.IsSuccessful)
            {
                response.Errors.ForEach(error => ModelState.AddModelError(String.Empty, error));

                return View();
            }
            
            return RedirectToAction(nameof(Index),"Home");
        }

        public async Task<IActionResult> SignOut(SignInInput signInInput)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _identityService.RevokeRefreshToken();
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }
    }
}
