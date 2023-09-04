using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.manha.Lucas.Domains;
using webapi.filmes.manha.Lucas.Interface;
using webapi.filmes.manha.Lucas.Repositorys;

namespace webapi.filmes.manha.Lucas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Login(UsuarioDomain usuario)
        {
           UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha inválidos");

            }
            return Ok(usuarioBuscado);
        }
    }
}
