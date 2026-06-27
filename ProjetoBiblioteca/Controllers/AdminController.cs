using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Data;

namespace ProjetoBiblioteca.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalLivros = _context.Livros.Count();
            ViewBag.TotalServicos = _context.Servicos.Count();

            return View();
        }
    }
}