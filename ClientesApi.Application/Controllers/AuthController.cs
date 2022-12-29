using ClientesApi.Application.Requests;
using ClientesApi.Application.Responses;
using ClientesApi.Application.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientesApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(AuthPostRequest request)
        {
            try
            {
                var emailUsuario = "admin@gmail.com";
                var senhaUsuario = "adminadmin";

                if (emailUsuario.Equals(request.Email) && senhaUsuario.Equals(request.Senha))
                {
                    var response = new AuthGetResponse
                    {
                        NomeUsuario = "Administrador",
                        EmailUsuario = emailUsuario,
                        AccessToken = JwtSecurity.CreateToken(emailUsuario),
                        DataHoraAcesso = DateTime.Now
                    };

                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(401, new { message = "Acesso negado. Usuário inválido." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}



