using System.ComponentModel.DataAnnotations;

namespace ProjetoBiblioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O autor é obrigatório.")]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço é obrigatório.")]
        public decimal Preco { get; set; }

        //[Required(ErrorMessage = "A imagem é obrigatória.")]
        public string ImagemUrl { get; set; } = string.Empty;

        //[Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty;
    }
}