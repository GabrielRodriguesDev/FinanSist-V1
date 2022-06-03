using System.Net;
using FinanSist.Domain.Commands;
using Newtonsoft.Json;

namespace FinanSist.WebApi.Middleware
{
    public class ErrorHandlerMiddleware //MiddleWare para erros genéricos.
    {
        //ErrorHandlingMiddleware, responsável por capturar todos os erros (sem tratamento) da aplicação
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {

            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var result = new GenericCommandResult(false, "(E0029) - " + exception.Message);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}