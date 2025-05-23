using EShop.MVC.Models;
using EShop.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EShop.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IToastNotification _toastNotification;
        //constructor injection.
        public AuthController(IAuthService authService, IToastNotification toastNotification)
        {
            _authService = authService;
            _toastNotification = toastNotification;
        }

        public ActionResult Index()
        {
            // Login olmuş kullacının profil sayfası olabilir
            return View();
        }

        public IActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost] //login olma işlemi için post metot.
        public async Task<IActionResult> Login(LoginModel loginModel, string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }
            var response = await _authService.LoginAsync(loginModel);
            if (!response.IsSuccessful)
            {
                _toastNotification.AddErrorToastMessage(response.Error ?? "Giriş yapılırken bir hata oluştu");
                return View(loginModel);
            }
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl); //Redirect kullanım amacı kullanıcının giriş yapmadan önce gitmek istediği sayfaya yönlendirmek
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
