using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Models;

namespace ProjetoBiblioteca.Controllers
{
    public class LivrosController : Controller
    {
        public IActionResult Index()
        {
            var livros = new List<Livro>
            {
                new Livro
                {
                    Id = 1,
                    Titulo = "Teste 1",
                    Autor = "Pedro",
                    Categoria = "Teste",
                    Preco = 89.90m
                },
                new Livro
                {
                    Id = 2,
                    Titulo = "Teste 2",
                    Autor = "Henrique",
                    Categoria = "Teste",
                    Preco = 59.90m
                }
            };

            return View(livros);
        }
    }
}