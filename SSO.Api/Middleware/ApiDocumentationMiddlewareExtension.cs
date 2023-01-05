using Microsoft.OpenApi.Models;

namespace SSO.Api.Middleware
{
    public static class ApiDocumentationMiddlewareExtension
    {
        public static void ConfigureDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer> {
                        new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" },
                        new OpenApiServer { Url = "http://nginx.saminray.com:30080/dev-sso" },
                    };
                });
            });
            app.UseSwaggerUI();
        }
    }
}
