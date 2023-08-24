using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.manha.Lucas.Domains
{
    public class GeneroDomain
    {

        public int IdGenero { get; set; }
        [Required(ErrorMessage = "Nome do Gênero invalido")]

        public string Nome { get; set; }
       
    }
   
}
