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
                RetornarStatusCodeException(httpContext, ex.Message, ex.InnerException.ToString());
            }
        }

        private void RetornarStatusCodeException(HttpContext httpContext, string mensagemErro, string innerException)
        {
            httpContext.Response.StatusCode = 500;
            httpContext.Response.WriteAsJsonAsync( new { mensagem = $"Não foi possível realizar a operação! Mensagem: {mensagemErro}{innerException}"});

        }
    }
}
