using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinanSist.Domain.Commands.Entidade;
using FinanSist.Domain.Commands.Usuario;
using FinanSist.Domain.Interfaces.Services;

namespace FinanSist.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntidadeController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromServices] IEntidadeService entidadeService, CreateEntidadeCommand createEntidadeCommand)
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
        [Authorize]
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
    }
}