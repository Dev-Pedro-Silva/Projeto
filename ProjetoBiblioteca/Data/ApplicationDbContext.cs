using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Models;

namespace ProjetoBiblioteca.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Servico> Servicos { get; set; }
    }
}