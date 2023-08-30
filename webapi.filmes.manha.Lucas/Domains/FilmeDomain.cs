using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.manha.Lucas.Domains
{
    public class FilmeDomain
    {
        [Required]  
        public int IdFilme { get; set; }

        [Required]
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O nome do filme é obrigatório!")]
        public string? Titulo { get; set; }
        [Required(ErrorMessage = "Nome do filme invalido")]
        public GeneroDomain Genero { get; set; }      
    }
}
