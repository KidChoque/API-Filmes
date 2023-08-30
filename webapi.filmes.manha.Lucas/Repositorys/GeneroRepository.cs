using Microsoft.AspNetCore.HttpOverrides;
using System.Data.SqlClient;
using webapi.filmes.manha.Lucas.Domains;
using webapi.filmes.manha.Lucas.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.manha.Lucas.Repositorys
{
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source = NOTE08-S14; Initial Catalog = Filmes; User ID = sa; Pwd=Senai@134";

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> ListaGenero = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdGenero,Nome FROM Genero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))

                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),

                            Nome = rdr["Nome"].ToString()
                        };

                        ListaGenero.Add(genero);
                    }

                }

            }
            return ListaGenero;

        }

        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a conexão com o BAnco de Dados passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Anti Sql Injection
                string queryInsert = "INSERT INTO Genero(Nome) VALUES(@Nome)";

                //Declara o SqlCommand passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Comando que executa a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    con.Open();

                    cmd.ExecuteNonQuery();


                }
            };


        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public GeneroDomain? BuscarPorId(int id)
        {



            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryBuscarPorId = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarPorId, con))
                {

                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    rdr = cmd.ExecuteReader();


                    if (rdr.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {

                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };

                        return generoBuscado;
                    }
                    return null;



                }
            }


        }

        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAtualizarIdCorpo = "Update Genero set Nome = @Nome Where IdGenero = @IdGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryAtualizarIdCorpo, con))
                {

                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    cmd.ExecuteNonQuery();

                }
            }

        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAtualizarIdUrl = "Update Genero set Nome = @Nome Where IdGenero = @IdGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryAtualizarIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    cmd.ExecuteNonQuery();

                }

               ;


            };

        }


    }
}
