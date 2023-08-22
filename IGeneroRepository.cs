using webapi.filmes.manha.Lucas.Domains;

namespace webapi.filmes.manha.Lucas.Interface
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository 
    /// Definir os métodos que serão implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //TipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)
        void Cadastrar(GeneroDomain novoGenero);

        List<GeneroDomain> ListarTodos();

        void AtualizarIdCorpo(GeneroDomain genero);

        void Deletar(int, );
    }
}
