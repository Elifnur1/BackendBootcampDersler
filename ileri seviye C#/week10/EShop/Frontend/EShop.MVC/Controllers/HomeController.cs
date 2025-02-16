using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EShop.MVC.Models;

namespace EShop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger; //Kodun amacı loglama yani hata takibi yapmak için kullanılır.

    public IActionResult Index()
    {
        return View();
    }


}
