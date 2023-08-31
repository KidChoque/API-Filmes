using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.manha.Lucas.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O nome do filme é obrigatório!")]
        public string? Titulo { get; set; }
        public GeneroDomain Genero { get; set; }      
    }
}
