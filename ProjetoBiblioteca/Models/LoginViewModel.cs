using System.ComponentModel.DataAnnotations;

namespace ProjetoBiblioteca.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a senha.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Lembrar de mim")]
        public bool RememberMe { get; set; }
    }
}