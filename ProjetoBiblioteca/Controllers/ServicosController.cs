using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Models;
using ProjetoBiblioteca.Data;


namespace ProjetoBiblioteca.Controllers
{
    public class ServicosController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public ServicosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servicos.ToListAsync());
        }

         public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servico);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(servico);
        }

    }
}