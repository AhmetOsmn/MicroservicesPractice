using MicroservicesPractice.Gateway.DelegateHandlers;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace MicroservicesPractice.Gateway
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient<TokenExchangeDelegateHandler>();

            builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToLower()}.json");

            builder.Services.AddAuthentication().AddJwtBearer("GatewayAuthenticationScheme", options =>
            {
                options.Authority = builder.Configuration["IdentityServerUrl"];
                options.Audience = "resource_gateway";
                options.RequireHttpsMetadata = false;
            });

            builder.Services.AddOcelot().AddDelegatingHandler<TokenExchangeDelegateHandler>();

            var app = builder.Build();

            await app.UseOcelot();

            app.Run();
        }
    }
}