using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
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


            if (e.GetType() == typeof(SecurityException))//Eğer bir SecurityException hatası alınırsa buraya geliyor ve aldığın hata SecurityException ise bir mesaj oluşturuyor
            {
                message = e.Message;
                httpContext.Response.StatusCode = 403;

                return httpContext.Response.WriteAsync(new SecurityErrorDetail //Validasyon hatası dönerse bu çalışacak
                {
                    StatusCode = 403,
                    Message = message
                }.ToString());
            }
            else if (e.GetType() == typeof(ValidationException))//Eğer bir ValidationException hatası alınırsa buraya geliyor ve aldığın hata ValidationException ise bir mesaj oluşturuyor
            {
                message = e.Message;
                IEnumerable<ValidationFailure> errors = ((ValidationException)e).Errors;
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
                Message = e.Message
            }.ToString());
        }
    }
}
