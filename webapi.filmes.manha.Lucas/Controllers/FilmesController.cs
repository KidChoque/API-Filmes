using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.manha.Lucas.Domains;
using webapi.filmes.manha.Lucas.Interface;
using webapi.filmes.manha.Lucas.Repositorys;

namespace webapi.filmes.manha.Lucas.Controllers

{  //Definie que a rota de uma requisição será no seguinte formato
    //domínio/api/nomeController
    //ex:https://localhost:7156/api/Filmes

    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Método controlador que herda da controller base
    //Onde será criado os Endpoints(Rotas)
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet]

        public IActionResult ListarFilme()
        {
            try
            {
                List<FilmeDomain> ListaFilme = _filmeRepository.ListarTodos();

                return Ok(ListaFilme);
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message);
            }
        }

    }
}






    