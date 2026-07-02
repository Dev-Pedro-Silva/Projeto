using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Data;
using ProjetoBiblioteca.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoBiblioteca.Controllers
{

    public class LivrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LivrosController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string pesquisa)
        {
            var livros = from l in _context.Livros
                         select l;

            if (!string.IsNullOrWhiteSpace(pesquisa))
            {
                livros = livros.Where(l =>
                    l.Titulo.Contains(pesquisa) ||
                    l.Autor.Contains(pesquisa) ||
                    l.Categoria.Contains(pesquisa));
            }

            return View(await livros.ToListAsync());
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(Livro livro, IFormFile? imagem)
        {
            if (ModelState.IsValid)
            {
                if (imagem == null || imagem.Length == 0)
                {
                    ModelState.AddModelError("", "Selecione uma imagem para o livro.");
                }
                if (imagem != null && imagem.Length > 0)
                {
                    var extensoesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".webp" };

                    var extensao = Path.GetExtension(imagem.FileName).ToLower();

                    if (!extensoesPermitidas.Contains(extensao))
                    {
                        ModelState.AddModelError("", "Formato de imagem inválido.");
                        return View(livro);
                    }

                    var pasta = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot/images/livros");

                    if (!Directory.Exists(pasta))
                    {
                        Directory.CreateDirectory(pasta);
                    }

                    var nomeArquivo = Guid.NewGuid().ToString() + extensao;

                    var caminho = Path.Combine(pasta, nomeArquivo);

                    using (var stream = new FileStream(caminho, FileMode.Create))
                    {
                        await imagem.CopyToAsync(stream);
                    }

                    livro.ImagemUrl = "/images/livros/" + nomeArquivo;
                }

                _context.Add(livro);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(livro);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, Livro livro, IFormFile? imagem)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var livroBanco = await _context.Livros.FindAsync(id);

                if (livroBanco == null)
                {
                    return NotFound();
                }

                livroBanco.Titulo = livro.Titulo;
                livroBanco.Autor = livro.Autor;
                livroBanco.Categoria = livro.Categoria;
                livroBanco.Descricao = livro.Descricao;
                livroBanco.Disponivel = livro.Disponivel;

                if (imagem != null && imagem.Length > 0)
                {
                    var extensoesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".webp" };

                    var extensao = Path.GetExtension(imagem.FileName).ToLower();

                    if (!extensoesPermitidas.Contains(extensao))
                    {
                        ModelState.AddModelError("", "Formato de imagem inválido.");
                        return View(livro);
                    }

                    if (!string.IsNullOrEmpty(livroBanco.ImagemUrl))
                    {
                        var imagemAntiga = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot",
                            livroBanco.ImagemUrl.TrimStart('/'));

                        if (System.IO.File.Exists(imagemAntiga))
                        {
                            System.IO.File.Delete(imagemAntiga);
                        }
                    }

                    var pasta = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot/images/livros");

                    if (!Directory.Exists(pasta))
                    {
                        Directory.CreateDirectory(pasta);
                    }

                    var nomeArquivo = Guid.NewGuid().ToString() + extensao;

                    var caminho = Path.Combine(pasta, nomeArquivo);

                    using (var stream = new FileStream(caminho, FileMode.Create))
                    {
                        await imagem.CopyToAsync(stream);
                    }

                    livroBanco.ImagemUrl = "/images/livros/" + nomeArquivo;
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(livro);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro != null)
            {
                if (!string.IsNullOrEmpty(livro.ImagemUrl))
                {
                    var caminhoImagem = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        livro.ImagemUrl.TrimStart('/'));

                    if (System.IO.File.Exists(caminhoImagem))
                    {
                        System.IO.File.Delete(caminhoImagem);
                    }
                }

                _context.Livros.Remove(livro);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = await _context.Livros
                .FirstOrDefaultAsync(l => l.Id == id);

            if (livro == null)
                return NotFound();

            return View(livro);
        }

        [HttpGet]
        public async Task<IActionResult> Emprestar(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
                return NotFound();

            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Emprestar(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
                return NotFound();

            if (!livro.Disponivel)
            {
                TempData["Erro"] = "Este livro já está indisponível.";
                return RedirectToAction(nameof(Details), new { id });
            }

            livro.Disponivel = false;

            await _context.SaveChangesAsync();

            TempData["Sucesso"] = "Empréstimo solicitado com sucesso!";

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}