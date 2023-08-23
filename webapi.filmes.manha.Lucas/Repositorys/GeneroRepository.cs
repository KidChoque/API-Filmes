using Microsoft.AspNetCore.HttpOverrides;
using System.Data.SqlClient;
using webapi.filmes.manha.Lucas.Domains;
using webapi.filmes.manha.Lucas.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.manha.Lucas.Repositorys
{
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source = NOTE08-S14; Initial Catalog = Filmes; User ID = SA; Pwd=senai@134;";

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> ListaGenero = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdGenro,Nome FROM Genero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll))
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
                return ListaGenero;
                }

            }
        }
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

      

    
    }
}
