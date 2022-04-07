using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinanSist.Domain.Commands.Usuario;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Interfaces.Services;
using FinanSist.Domain.Queries;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Commands;

namespace FinanSist.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] IUsuarioService service, [FromBody] CreateUsuarioCommand cmd)
        {
            var tsc = new TaskCompletionSource<IActionResult>(); // Iniciando a tarefa
            try
            {
                var result = service.Create(cmd);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(0001) - " + e.Message))
                {
                    StatusCode = 500
                });
            } // Final da tarefa
            return await tsc.Task; // Aguardando a conclusção da tarefa para poder retornar a tarefa
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromServices] IUsuarioService service, [FromBody] UpdateUsuarioCommand cmd)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = service.Update(cmd);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(0002) - " + e.Message))
                {
                    StatusCode = 500
                });
            }

            return await tsc.Task;
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete([FromServices] IUsuarioService service, [FromRoute] Guid id)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = service.Delete(id);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {

                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(0003) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Get([FromServices] IUsuarioRepository repository, [FromRoute] Guid id)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var searchFormParams = new SearchFormParams();
                searchFormParams.Id = id;
                searchFormParams.NomeTabela = "Usuario";
                searchFormParams.CamposTabela = UsuarioQueries.ExtrairCamporForm().CamposTabela;

                dynamic? result = repository.PesquisarForm(searchFormParams);
                if (result == null) new GenericCommandResult(false, "Desculpe, usuário não foi localizado.");

                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(0004) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpPost]
        [Route("pesquisar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Pequisar([FromServices] IUsuarioRepository usuarioRepository, [FromBody] SearchParams searchParams)
        {
            var tsc = new TaskCompletionSource<IActionResult>();

            try
            {
                searchParams.NomeTabela = "Usuario";
                searchParams.CamposTabela = UsuarioQueries.ExtrairCamposLista().CamposTabela;
                searchParams.TextosFiltroTabela = UsuarioQueries.ExtrairCamposLista().TextosFiltro;

                dynamic result = usuarioRepository.Pesquisar(searchParams);
                if (result.Count == 0) result = new GenericCommandResult(false, "Desculpe, nenhum registro foi localizado.");
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(0005) - " + e.Message)));
            }
            return await tsc.Task;
        }


    }
}