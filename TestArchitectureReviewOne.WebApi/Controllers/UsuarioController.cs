using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestArchitectureReviewOne.Domain.Commands.Usuario;
using TestArchitectureReviewOne.Domain.Interfaces.Repositories;
using TestArchitectureReviewOne.Domain.Interfaces.Services;
using TestArchitectureReviewOne.Domain.Queries;
using TestArchitectureReviewOne.Domain.Queries.Params;

namespace TestArchitectureReviewOne.WebApi.Controllers
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
                while (e.InnerException != null)
                    e = e.InnerException;

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
        public async Task<IActionResult> Get([FromServices] IUsuarioRepository repository, [FromRoute] Guid id)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var searchFormParams = new SearchFormParams();
                dynamic? result;
                searchFormParams.Id = id;
                searchFormParams.NomeTabela = "Usuario";
                searchFormParams.CamposTabela = UsuarioQueries.ExtrairCamporForm().CamposTabela;

                result = repository.PesquisarForm(searchFormParams);
                if (result == null) new GenericCommandResult(false, "Desculpe, usuário não foi localizado.");

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
    }
}