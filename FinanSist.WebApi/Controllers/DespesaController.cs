using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.Despesa;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Interfaces.Services;
using FinanSist.Domain.Queries;
using FinanSist.Domain.Queries.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanSist.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DespesaController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromServices] IDespesaService despesaService, [FromBody] CreateDespesaCommand createDespesaCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = despesaService.Create(createDespesaCommand);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0024) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromServices] IDespesaService despesaService, [FromBody] UpdateDespesaCommand updateDespesaCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = despesaService.Update(updateDespesaCommand);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0025) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromServices] IDespesaService despesaService, [FromRoute] Guid id)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = despesaService.Delete(id);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0026) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromServices] IDespesaRepository despesaRepostory, [FromRoute] Guid id)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                SearchFormParams searchFormParams = new SearchFormParams();
                searchFormParams.Id = id;
                searchFormParams.NomeTabela = "Despesa";
                searchFormParams.CamposTabela = DespesaQueries.ExtrairCamposForm().CamposTabela;

                var result = despesaRepostory.PesquisarForm(searchFormParams);
                if (result == null) new GenericCommandResult(true, "Desculpe, despesa não foi localizada.");

                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0027) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpPost]
        [Authorize]
        [Route("pesquisar")]
        public async Task<IActionResult> Pesquisar([FromServices] IDespesaRepository despesaRepository, [FromBody] SearchParams? searchParams)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var campos = DespesaQueries.ExtrairCamposLista();
                if (searchParams == null)
                {
                    searchParams = new SearchParams();
                }
                searchParams.NomeTabela = "Despesa";
                searchParams.CamposTabela = campos.CamposTabela;
                searchParams.TextosFiltroTabela = campos.TextosFiltro;

                dynamic result = despesaRepository.Pesquisar(searchParams);
                if (result.Count == 0) result = new GenericCommandResult(false, "Desculpe, nenhum registro foi localizado.");

                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
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
    }
}