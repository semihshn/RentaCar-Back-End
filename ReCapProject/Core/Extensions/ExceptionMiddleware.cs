using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
	public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)//Fron-end'den gelen tüm http istekleri buradaki try/catch içinden geçer
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            IEnumerable<ValidationFailure> errors;
            if (e.GetType() == typeof(ValidationException))//Eğer bir hata alınırsa buraya geliyor ve aldığın hata ValidationException ise bir mesaj oluşturuyor
            {
                message = e.Message;
                errors = ((ValidationException)e).Errors;
                httpContext.Response.StatusCode = 400;

                return httpContext.Response.WriteAsync(new ValidationErrorDetails//Validasyon hatası dönerse bu çalışacak
                {
                    StatusCode = 400,
                    Message = message,
                    ValidationErrors = errors
                }.ToString());
            }

            return httpContext.Response.WriteAsync(new ErrorDetails//Eğer sistem hata verirse back-end'in frontend'e ne döndereceğini belirtiyor , sınırlandırıyoruz burada
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
