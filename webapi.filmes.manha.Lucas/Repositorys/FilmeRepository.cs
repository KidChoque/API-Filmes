using System.Data.SqlClient;
using webapi.filmes.manha.Lucas.Domains;
using webapi.filmes.manha.Lucas.Interface;

namespace webapi.filmes.manha.Lucas.Repositorys
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = NOTE08-S14; Initial Catalog = Filmes; User ID = sa; Pwd=Senai@134";

        public object Genero { get; private set; }

        public List<FilmeDomain> ListarTodos()
        {

            List<FilmeDomain> ListaFilme = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //string querySelectAll = "select Genero.Nome AS 'Genero',Filme.Titulo from Filme\r\nJoin Genero on Genero.IdGenero = Filme.IdGenero ";
                string querySelectAll = "select Filme.IdFilme  ,Genero.IdGenero,Genero.Nome,Filme.Titulo from Filme\r\nJoin Genero on Genero.IdGenero = Filme.IdGenero ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain Filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            IdGenero = Convert.ToInt32(rdr[0]),

                            Titulo = rdr["Titulo"].ToString(),

                            Genero = new GeneroDomain()
                            {
                                Nome = rdr["Nome"].ToString() 
                            }
                        };
                        //GeneroDomain Genero = new GeneroDomain()
                        //{
                        //    Nome = rdr["Genero.Nome"].ToString(), 
                        //};
                        ListaFilme.Add(Filme);
                    }
                }
                return ListaFilme;
            }

        }
        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }
        public void Cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }



    }
}
