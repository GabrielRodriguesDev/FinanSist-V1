using System.Net;
using Microsoft.AspNetCore.Mvc;
using TestArchitectureReviewOne.Domain.Interfaces.Repositories;

namespace TestArchitectureReviewOne.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    [HttpGet]
    [Route("{nome}")]
    public async Task<IActionResult> Get([FromServices] IEntidadeRepository service, [FromRoute] string nome)
    {
        var tsc = new TaskCompletionSource<IActionResult>();
        try
        {
            var result = service.ExistePorNome(nome);

            tsc.SetResult(new JsonResult(result)
            {
                StatusCode = 200
            });
        }
        catch (Exception ex)
        {

            tsc.SetResult(new JsonResult(ex.Message)
            {
                StatusCode = 500,

            });
        }

        return await tsc.Task;
    }
}
