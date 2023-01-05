using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace SSO.Common.ExtensionMethods
{
    public static class HttpContextExtension
    {
        public static string GetIp(this HttpContext context)
        {
            var remoteIpAddress = context.Connection.RemoteIpAddress;
            return remoteIpAddress.ToString();
        }
        public static string GetDeviceName(this HttpContext context)
        {
            var deviceName = Dns.GetHostName();
            return deviceName;
        }

        public static string GetBrowserName(this HttpContext context)
        {
            if (context.Request.Headers.Any(x => x.Key == "User-Agent"))
                return context.Request.Headers["User-Agent"].ToString();
            return "USER-AGENT-NOT-FOUND";
        }



        //public static Guid GetTopicId(this HttpContext httpContext)
        //{
        //    var secret = httpContext.Request.Headers["topic-id"];
        //    if (string.IsNullOrEmpty(secret))
        //        throw new MissingAppSecretException();
        //    var topicId = Guid.Empty;
        //    Guid.TryParse(secret, out topicId);
        //    return topicId;
        //}


        //public static AthenticatedUser GetUser(this HttpContext httpContext)
        //{
        //    if (httpContext.User == null)
        //        return null;
        //    if (!httpContext.User.Claims.Any())
        //        return null;
        //    var claims = httpContext.User.Claims;
        //    var MobileNumber = claims?.FirstOrDefault(x => x.Type == ClaimTypes.MobilePhone)?.Value;
        //    var UserId = int.Parse(claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        //    var result = new AthenticatedUser()
        //    {
        //        MobileNo = MobileNumber,
        //        UserId = UserId
        //    };


    }
    }
