using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Models;

namespace ProjetoBiblioteca.Controllers
{
    public class ServicosController : Controller
    {
        public IActionResult Index()
        {
            var servicos = new List<Servico>
            {
                new Servico
                {
                    Id = 1,
                    Nome = "Empréstimo de Livros",
                    Descricao = "Empréstimo por até 15 dias."
                },
                new Servico
                {
                    Id = 2,
                    Nome = "Reserva de Livros",
                    Descricao = "Reserva online do acervo."
                }
            };

            return View(servicos);
        }
    }
}