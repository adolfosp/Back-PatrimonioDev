using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PatrimonioDev.Extension
{
    public class ExceptionMiddleware : ControllerBase
    {

        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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
                await RetornarStatusCodeException(ex.Message, ex.InnerException.ToString());
            }
        }

        private async Task<IActionResult> RetornarStatusCodeException(string mensagemErro, string innerException)
        {
           return  StatusCode(500, new { mensagem = $"Não foi possível realizar a operação! Mensagem: {mensagemErro}{innerException}" });
        }
    }
}
