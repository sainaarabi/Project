using Microsoft.AspNetCore.Diagnostics;
using SSO.Api.Model;
using SSO.Common.Exceptions;
using SSO.Core;
using System.Net;

namespace SSO.Api.Middleware
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        if (contextFeature.Error != null && contextFeature.Error is AuthorizeException)
                        {
                            var exception = (AuthorizeException)contextFeature.Error;
                            context.Response.StatusCode = (int)Common.AppExceptionBaseType.Forbidden;
                            await context.Response.WriteAsync(new CustomError()
                            {
                                Message = exception.Message,
                                ErrorCode = exception.Code
                            }.ToString());
                            return;
                        } 

                        if (contextFeature.Error != null && contextFeature.Error is AppException)
                        {
                            var exception = (AppException)contextFeature.Error;
                            context.Response.StatusCode = (int)Common.AppExceptionBaseType.NotFound;
                            await context.Response.WriteAsync(new CustomError()
                            {
                                Message = exception.Message,
                                ErrorCode = exception.Code
                            }.ToString());
                            return;
                        }
                        else if (contextFeature.Error != null &&
                        contextFeature.Error is BusinessRuleValidationException)
                        {
                            var bussinessException = (BusinessRuleValidationException)contextFeature.Error;
                            context.Response.StatusCode = (int)Common.AppExceptionBaseType.Bussiness;
                            await context.Response.WriteAsync(new CustomError()
                            {
                                Message = bussinessException.BrokenRule.Message,
                                ErrorCode = bussinessException.BrokenRule.ErrorCode
                            }.ToString());
                            return;
                        }
                    }
                });
            });
        }
    }
}

