using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.manha.Lucas.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        public string? Titulo { get; set; }
        [Required(ErrorMessage = "Nome do filme invalido")]
        public GeneroDomain Genero { get; set; }

        
    }
}
