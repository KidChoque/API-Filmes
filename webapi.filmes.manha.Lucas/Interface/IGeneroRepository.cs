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

        /// <summary>
        /// Cadastra um objeto, sem retorno
        /// </summary>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Lista os objetos da Lista GeneroDomain e os retorna.
        /// </summary>
        List<GeneroDomain> ListarTodos();

        /// Atualiza o objeto passando seu id no corpo da requisição
        void AtualizarIdCorpo(GeneroDomain genero);

        ///Atualiza o objeto pelo id na URL
        void AtualizarIdUrl(int id,GeneroDomain genero);

        ///Deleta o objeto pelo id
        void Deletar(int id);

        /// Busca objeto pelo ID
        GeneroDomain BuscarPorId(int id);
    }
}
