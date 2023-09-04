using webapi.filmes.manha.Lucas.Domains;

namespace webapi.filmes.manha.Lucas.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);
    }
}
