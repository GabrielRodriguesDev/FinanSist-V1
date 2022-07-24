using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinanSist.Domain.Commands.Entidade;
using FinanSist.Domain.Interfaces.Services;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Queries;
using FinanSist.Domain.Commands;
using Prometheus;

namespace FinanSist.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntidadeController : ControllerBase
    {
        private static readonly Counter _CounterGetAll = Metrics
    .CreateCounter("finansist_counter_getall", "Número de chamadas ao get all.");



        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create([FromServices] IEntidadeService entidadeService, [FromBody] CreateEntidadeCommand createEntidadeCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = entidadeService.Create(createEntidadeCommand);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0014) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromServices] IEntidadeService entidadeService, [FromBody] UpdateEntidadeCommand updateEntidadeCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = entidadeService.Update(updateEntidadeCommand);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0015) - " + e.Message))
                {
                    StatusCode = 500
                });
                throw;
            }
            return await tsc.Task;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromServices] IEntidadeService entidadeService, [FromRoute] Guid id)
        {
            var tsc = new TaskCompletionSource<IActionResult>();

            try
            {
                var result = entidadeService.Delete(id);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0016) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromServices] IEntidadeRepository repository, [FromRoute] Guid id)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {

                var searchFormParams = new SearchFormParams();
                searchFormParams.Id = id;
                searchFormParams.NomeTabela = "Entidade";
                searchFormParams.CamposTabela = EntidadeQueries.ExtrairCamposForm().CamposTabela;

                var result = repository.PesquisarForm(searchFormParams);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0017) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpPost]
        [Route("Pesquisar")]
        //[Authorize]
        public async Task<IActionResult> Pesquisar([FromServices] IEntidadeRepository repository, [FromBody] SearchParams? searchParams)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var campos = EntidadeQueries.ExtrairCamposLista();
                if (searchParams == null)
                {
                    searchParams = new SearchParams();
                }
                searchParams.NomeTabela = "Entidade";
                searchParams.CamposTabela = campos.CamposTabela;
                searchParams.TextosFiltroTabela = campos.TextosFiltro;

                dynamic result = repository.Pesquisar(searchParams);
                if (result.Count == 0) result = new GenericCommandResult(false, "Desculpe, nenhum registro foi localizado.");

                _CounterGetAll.Inc();
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0018) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }
    }
}