using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project05_MVC_Temelleri.Models;

namespace Project05_MVC_Temelleri.Controllers;
//Controllerlar isimlendirilirken mutlaka Controller ifadesi ile bitmek zorundadır.
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
}
