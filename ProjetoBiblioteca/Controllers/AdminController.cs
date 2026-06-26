using Microsoft.AspNetCore.Mvc;

namespace ProjetoBiblioteca.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}