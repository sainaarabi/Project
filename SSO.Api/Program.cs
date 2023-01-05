using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json.Serialization;
using SSO.Api.Configurations;
using SSO.Api.Middleware;
using SSO.Booster;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddInitializer(configuration, typeof(Program));
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .SetIsOriginAllowed(_ => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );
});
builder.Services.AddApiServices();

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
builder.Services.Configure<KestrelServerOptions>(configuration.GetSection("Kestrel"));

var app = builder.Build();

app.ConfigureExceptionHandler();

app.UseRouting();
app.MapControllers();
//app.UseDeveloperExceptionPage();
app.ConfigureDocumentation();
app.UseCors("CorsPolicy");
app.Run();

app.UseSession();


