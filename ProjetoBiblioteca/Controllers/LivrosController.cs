using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Data;
using ProjetoBiblioteca.Models;

namespace ProjetoBiblioteca.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lista todos os livros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Livros.ToListAsync());
        }
    }
}