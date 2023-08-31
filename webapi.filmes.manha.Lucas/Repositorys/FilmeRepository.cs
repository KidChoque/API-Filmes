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
        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string queryInsert = "INSERT INTO Filme VALUES(@IdGenero,@Titulo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                };
            }
        }
        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryBuscarPorId = "SELECT IdFilme, Titulo FROM Filme WHERE IdFilme = @IdFilme ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarPorId, con))
                {

                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    rdr = cmd.ExecuteReader();


                    if (rdr.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = rdr["Titulo"].ToString()
                        };


                        return filmeBuscado;
                    }
                    return null;

                }

              

            }



        }

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string queryAtualizarIdCorpo = "UPDATE Filme SET Titulo = @Titulo Where IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryAtualizarIdCorpo, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAtualizarIdUrl = "UPDATE Filme SET Titulo = @Titulo Where IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryAtualizarIdUrl, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDeletar = "DELETE FROM Filme Where IdFilme = @IdFilme";

                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
         
        }
    }


}
