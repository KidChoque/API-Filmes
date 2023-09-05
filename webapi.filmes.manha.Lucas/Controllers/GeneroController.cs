using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.manha.Lucas.Domains;
using webapi.filmes.manha.Lucas.Interface;
using webapi.filmes.manha.Lucas.Repositorys;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.manha.Lucas.Controllers
{
    //Definie que a rota de uma requisição será no seguinte formato
    //domínio/api/nomeController
    //ex: https://localhost:7156/api/Filmes

    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Método controlador que herda da controller base
    //Onde será criado os Endpoints(Rotas)

    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que irá receber todos os métodos definidos na Interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referência aos métodos no repositório 
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que aciona o método ListarTodos no repositório
        /// </summary>
        /// <returns>Resposta para o usuário(front-end)</returns>
        [HttpGet]
        [Authorize(Roles = "Administrador,Comum")]

        //ListarGwnero=GET
        public IActionResult ListarGenero()
        {

            try
            {
                //Cria uma lista que recebe os dados da requisição 
                List<GeneroDomain> ListaGenero = _generoRepository.ListarTodos();

                //Retorna a lista do formato JSON com o status code OK(200)
                return Ok(ListaGenero);
            }

            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }



        }

        // InserirGenero = Post
        /// <summary>
        /// Endpoint que aciona método de cadastro de gênero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisição</param>
        /// <returns>status code 201(Created)</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult InserirGenero(GeneroDomain novoGenero)
        {
            try
            {
                // FAzendo a chamada para o método cadastrar 
                _generoRepository.Cadastrar(novoGenero);

                return StatusCode(201);
            }
            catch (Exception Erro)
            {
                // Retorna status code(400) e a mensagem do erro
                return BadRequest(Erro.Message);

            }

        }

        [HttpDelete("{id}")]
        //DeletarGenero = Delete
        public IActionResult DeletarGenero(int id)
        {
            try
            {
                _generoRepository.Deletar(id);
                return StatusCode(200);

            }
            catch (Exception Erro)
            {
                return BadRequest(Erro.Message);
            }





        }

        [HttpGet("{id}")]
        //BuscarPorId = Get by Id
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado == null)
                {
                    return NotFound("Nenhum gênero foi encontrado")
                ;
                };

                return Ok(generoBuscado);
            }
            catch (Exception Erro)
            {
                return BadRequest(Erro.Message);
            }

        }

        [HttpPut("{id}")]

        public IActionResult AtualizarIdUrl(int id, GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {

                        _generoRepository.AtualizarIdUrl(id, genero);
                        return StatusCode(200);
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }

                }
                throw new Exception();

            }
            catch (Exception Erro)
            {
                BadRequest(Erro.Message);
            }

            return BadRequest();
        }

        [HttpPut]

        public IActionResult AtualizarIdCorpo(GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {

                        _generoRepository.AtualizarIdCorpo(genero);
                        return NoContent();

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
                return BadRequest(400);
            }

        }



    }
}
