using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.manha.Lucas.Domains
{
    public class UsuarioDomain
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Email { get; set; }

        [StringLength(20,MinimumLength = 3, ErrorMessage ="A senha deve ter de 3 a 20 caracteres")]
        [Required(ErrorMessage = "O camposenha é obrigatório")]
        public string Senha { get; set; }

        public string Permissao { get; set; }
        public int IdUsuario { get; internal set; }
    }
}
