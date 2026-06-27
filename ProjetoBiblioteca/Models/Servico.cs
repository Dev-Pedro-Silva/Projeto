using System.ComponentModel.DataAnnotations;

namespace ProjetoBiblioteca.Models
{
    public class Servico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "O valor é obrigatório.")]
        [Range(0, 9999.99, ErrorMessage = "Informe um valor válido.")]
        public decimal Valor { get; set; }
    }
}