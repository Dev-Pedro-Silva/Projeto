using Microsoft.AspNetCore.Identity;

namespace ProjetoBiblioteca.Data
{
    public static class SeedData
    {
        public static async Task CriarAdministrador(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string email = "admin@biblioteca.com";
            string senha = "Admin@123";

            var usuario = await userManager.FindByEmailAsync(email);

            if (usuario == null)
            {
                usuario = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(usuario, senha);
            }
        }
    }
} 