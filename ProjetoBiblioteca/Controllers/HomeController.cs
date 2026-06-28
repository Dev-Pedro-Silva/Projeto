using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Models;
using ProjetoBiblioteca.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjetoBiblioteca.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var livros = _context.Livros
            .OrderByDescending(l => l.Id)
            .Take(3)
            .ToList();

        return View(livros);
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
