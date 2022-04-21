using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinanSist.Domain.Commands.Autentica;

using FinanSist.Domain.Services;
using FinanSist.Domain.Interfaces.Services;
using FinanSist.Domain.Commands;

namespace FinanSist.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticaController : ControllerBase
    {
        #region  Controllers
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromServices] IAutenticaService service, [FromBody] LoginCommand cmd)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var refreshToken = TokenService.GenerateRefreshToken();
                var result = service.Login(cmd, refreshToken);
                if (result.Success)
                {
                    var token = TokenService.GenerateToken(result.Autenticado);

                    tsc.SetResult(new JsonResult(this.ResultLogin(result, token, "Login efetuado com sucesso"))
                    {
                        StatusCode = 200
                    });
                }
                else
                {
                    tsc.SetResult(new JsonResult(result)
                    {
                        StatusCode = 200
                    });
                }
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0006) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("EsqueceuSenha")]
        public async Task<IActionResult> EsqueceuSenha([FromServices] IAutenticaService service, [FromBody] EsqueceuSenhaCommand cmd)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = service.EsqueceuSenha(cmd);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }

                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0007) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromServices] IAutenticaService service, RefreshTokenCommand refreshTokenCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var refreshToken = TokenService.GenerateRefreshToken();
                var resfreshTokenAutenticado = TokenService.GetPrincipalFromExpiredToken(refreshTokenCommand);
                dynamic result;
                if (resfreshTokenAutenticado.Success)
                {
                    result = service.RefreshToken(resfreshTokenAutenticado, refreshToken);
                }
                else
                {
                    result = new RefreshTokenCommandResult(false, resfreshTokenAutenticado.Mensagem!, resfreshTokenAutenticado.Data);
                }
                if (result.Success)
                {
                    var token = TokenService.GenerateToken(result.Autenticado);

                    tsc.SetResult(new JsonResult(this.ResultRefresh(result, token, "Token atualizado com sucesso"))
                    {
                        StatusCode = 200
                    });
                }
                else
                {
                    tsc.SetResult(new JsonResult(result)
                    {
                        StatusCode = 200
                    });
                }
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0028) - " + e.Message))
                {
                    StatusCode = 500
                });
            }

            return await tsc.Task;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("AlterarSenha")]
        public async Task<IActionResult> AlterarSenha([FromServices] IAutenticaService service, [FromBody] AlterarSenhaCommand cmd)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = service.AlterarSenha(cmd);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0008) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }
        #endregion

        #region  Method
        private GenericCommandResult ResultLogin(LoginCommandResult result, string token, string mensagem)
        {
            return new GenericCommandResult(true, mensagem,
                    new
                    {
                        Nome = result.Autenticado.Nome,
                        Email = result.Autenticado.Email,
                        Token = token,
                        RefreshToken = result.Autenticado.RefreshToken,
                        Role = result.Autenticado.Permissao
                    });
        }

        private GenericCommandResult ResultRefresh(RefreshTokenCommandResult result, string token, string mensagem)
        {
            return new GenericCommandResult(true, mensagem,
                    new
                    {
                        Nome = result.Autenticado.Nome,
                        Token = token,
                        RefreshToken = result.Autenticado.RefreshToken,
                    });
        }
        #endregion
    }
}