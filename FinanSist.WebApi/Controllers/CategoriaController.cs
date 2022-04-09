using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinanSist.Domain.Commands.Categorias;
using FinanSist.Domain.Interfaces.Repositories;
using FinanSist.Domain.Interfaces.Services;
using FinanSist.Domain.Queries;
using FinanSist.Domain.Queries.Params;
using FinanSist.Domain.Commands;

namespace FinanSist.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromServices] ICategoriaService categoriaService, [FromBody] CreateCategoriaCommand createCategoriaCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();

            try
            {
                var result = categoriaService.Create(createCategoriaCommand);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0009) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromServices] ICategoriaService categoriaService, [FromBody] UpdateCategoriaCommand updateCategoriaCommand)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var result = categoriaService.Update(updateCategoriaCommand);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {

                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0010) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete([FromServices] ICategoriaService categoriaService, [FromRoute] Guid id)
        {
            var tsc = new TaskCompletionSource<IActionResult>();

            try
            {
                var result = categoriaService.Delete(id);
                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });

            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(0011) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Get([FromServices] ICategoriaRepository categoriaRepository, [FromRoute] Guid id)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {
                var searchFormParams = new SearchFormParams();
                searchFormParams.Id = id;
                searchFormParams.NomeTabela = "Categoria";
                searchFormParams.CamposTabela = CategoriaQueries.ExtrairCamposForm().CamposTabela;

                var result = categoriaRepository.PesquisarForm(searchFormParams);
                if (result == null) new GenericCommandResult(false, "Desculpe, categoria não foi localizada.");

                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });
            }
            catch (Exception e)
            {
                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0012) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }

        [HttpPost]
        [Route("pesquisar")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Pesquisar([FromServices] ICategoriaRepository categoriaRepository, [FromBody] SearchParams? searchParams)
        {
            var tsc = new TaskCompletionSource<IActionResult>();
            try
            {

                var campos = CategoriaQueries.ExtrairCamposLista();
                if (searchParams == null)
                {
                    searchParams = new SearchParams();
                }
                searchParams.NomeTabela = "Categoria";
                searchParams.CamposTabela = campos.CamposTabela;
                searchParams.TextosFiltroTabela = campos.TextosFiltro;

                dynamic result = categoriaRepository.Pesquisar(searchParams);
                if (result.Count == 0) result = new GenericCommandResult(false, "Desculpe, nenhum registro foi localizado.");

                tsc.SetResult(new JsonResult(result)
                {
                    StatusCode = 200
                });

            }
            catch (Exception e)
            {

                tsc.SetResult(new JsonResult(new GenericCommandResult(false, "(E0013) - " + e.Message))
                {
                    StatusCode = 500
                });
            }
            return await tsc.Task;
        }
    }
}