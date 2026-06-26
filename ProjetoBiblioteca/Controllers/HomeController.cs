using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Models;

namespace ProjetoBiblioteca.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Sobre()
    {
        return View();
    }

    public IActionResult Contato()
    {
        return View();
    }
}
