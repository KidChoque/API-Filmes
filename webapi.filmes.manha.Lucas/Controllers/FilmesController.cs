using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.manha.Lucas.Domains;
using webapi.filmes.manha.Lucas.Interface;
using webapi.filmes.manha.Lucas.Repositorys;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpPost]

        public IActionResult InserirFilme(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);
                return StatusCode(201);
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message);
            }
        }



        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("Nenhum filme foi encontrado");
                }
                return Ok(filmeBuscado);
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeletarFilme(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return Ok(200);
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message); 
            }
        }

        [HttpPut]
        public IActionResult AtualizarIdCorpo(FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filme.IdFilme);
                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdCorpo(filme);

                        return NoContent();
                    }
                    catch (Exception Erro)
                    {

                        return BadRequest(Erro.Message);
                    }
                }
                return NotFound();
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message);
            }

        }


        [HttpPut("{id}")]
        public IActionResult AtualizarIdUrl(int id, FilmeDomain filme)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filme.IdFilme);
            try
            {
                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdUrl(id, filme);
                        return StatusCode(201);
                    }
                    catch (Exception Erro)
                    {

                        return BadRequest(Erro.Message);
                    }
                }
                throw new Exception();
            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message);
            }
          

        }

    }

    
    }











