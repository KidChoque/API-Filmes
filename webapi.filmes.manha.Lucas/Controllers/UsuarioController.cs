using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

            try
            {
           UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha inválidos");

            }

                // Caso encontre o usuário,prossegue para a criação do token

                // 1° - Definir as informações(Claims) que serão fornecidos no token (PAYLOG)
                var claims = new[]
                {
                    //formato da claim
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role,usuarioBuscado.Permissao),
                    //existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada","Valor da Claim Personalizada")

                };


                //2° - Definir a chave de acesse ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("*filmes-chave-autenticadcao-webapi-dev"));

                //3° - Definir as credenciais do token (HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4°- Gerar Token
                var token = new JwtSecurityToken
                    (
                    //Emissor de token
                    issuer: "webapi.filmes.manha",

                    //Destinatário do token
                    audience: "webapi.filmes.manha",

                    //dados definidos nas claims(informações)
                    claims : claims,

                    //tempo de expiração do token
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciaisdo token
                    signingCredentials: creds


                    );

                //5° - retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                }
                );

            }
            catch (Exception Erro)
            {

                return BadRequest(Erro.Message);
            }
        }
    }
}
