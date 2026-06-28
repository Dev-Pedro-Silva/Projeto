using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Models;
using ProjetoBiblioteca.Data;
using Microsoft.AspNetCore.Authorization;


namespace ProjetoBiblioteca.Controllers
{

    public class ServicosController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ServicosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string pesquisa)
        {
            var servicos = from s in _context.Servicos
                           select s;

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                servicos = servicos.Where(l =>
                    l.Nome.Contains(pesquisa) ||
                    l.Descricao.Contains(pesquisa) ||
                    l.Categoria.Contains(pesquisa));
            }

            return View(await servicos.ToListAsync());
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos.FindAsync(id);

            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, Servico servico)
        {
            if (id != servico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(servico);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(servico);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos
                .FirstOrDefaultAsync(s => s.Id == id);

            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servico = await _context.Servicos.FindAsync(id);

            if (servico != null)
            {
                _context.Servicos.Remove(servico);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var servico = await _context.Servicos
                .FirstOrDefaultAsync(s => s.Id == id);

            if (servico == null)
                return NotFound();

            return View(servico);
        }

    }
}