//using System;
//using System.Linq;
//using NotifRay.Core.Domain;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using NotifRay.Api.Exceptions;
//using System.Security.Principal;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc.Filters;
//using MediatR;
//using NotifRay.Application.Apps.Queries;
//using NotifRay.Api.ExtensionMethods;
//using NotifRay.Core.Domain.Apps;
//using NotifRay.Application.Apps.Dtos;

//namespace NotifRay.Api.CustomAttribute
//{
//    public class AppSecretGuardAttribute : ActionFilterAttribute
//    {

//        public AppSecretGuardAttribute()
//        {
//        }

//        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//        {
//            var mediator = (IMediator)context.HttpContext.RequestServices.GetService(typeof(IMediator));
//            var secret = context.HttpContext.Request.Headers["app-secret"];
//            if (string.IsNullOrEmpty(secret))
//                throw new MissingAppSecretException();
//            var result = await mediator.Send(new GetAppWithSecretQuery(secret));
//            if (!result.IsSuccess)
//                throw new InvalidAppSecretException();
//            var appId = result.Data.CastTo<AppDto>().Id.ToString();

//            context.HttpContext.User.Claims.Append(new Claim("AppId", appId));

//            var claims = context.HttpContext.User.Claims;
//            var appIdAsString = claims?.FirstOrDefault(x => x.Type =="AppId")?.Value;


//            await next();
//        }
//    }
//}
