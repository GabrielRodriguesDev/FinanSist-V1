using FinanSist.Domain.Commands;
using FinanSist.Domain.Commands.Tag;
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
    public class TagController : ControllerBase
    {

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromServices] ITagService tagService, [FromBody] CreateTagCommand createTagCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = tagService.Create(createTagCommand);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0019) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromServices] ITagService tagService, [FromBody] UpdateTagCommand updateTagCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = tagService.Update(updateTagCommand);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0020) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromServices] ITagService tagService, [FromRoute] Guid id)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = tagService.Delete(id);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0021) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromServices] ITagRepository tagRepository, [FromRoute] Guid id)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                SearchFormParams searchFormParams = new SearchFormParams();
                searchFormParams.Id = id;
                searchFormParams.NomeTabela = "Tag";
                searchFormParams.CamposTabela = TagQueries.ExtrairCamposForm().CamposTabela;

                dynamic? result = tagRepository.PesquisarForm(searchFormParams);
                if (result == null) result = new GenericCommandResult(false, "Desculpe, Tag não foi localizado.");
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0022) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpPost]
        [Authorize]
        [Route("pesquisar")]
        public async Task<IActionResult> Pesquisar([FromServices] ITagRepository tagRepository, [FromBody] SearchParams? searchParams)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {

                var campos = TagQueries.ExtrairCamposLista();
                if (searchParams == null)
                {
                    searchParams = new SearchParams();
                }
                searchParams.NomeTabela = "Tag";
                searchParams.CamposTabela = campos.CamposTabela;
                searchParams.TextosFiltroTabela = campos.TextosFiltro;

                dynamic result = tagRepository.Pesquisar(searchParams);
                if (result.Count == 0) result = new GenericCommandResult(false, "Desculpe, nenhum registro foi encontrado.");
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0023) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }
    }
}