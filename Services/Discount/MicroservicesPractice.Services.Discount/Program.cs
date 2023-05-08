using MicroservicesPractice.Services.Discount.Services.Abstract;
using MicroservicesPractice.Services.Discount.Services.Concrete;
using MicroservicesPractice.Shared.Services.Abstract;
using MicroservicesPractice.Shared.Services.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace MicroservicesPractice.Services.Discount
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
            var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

            // Add services to the container.
            builder.Services.AddControllers(opt =>
            {
                opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = builder.Configuration["IdentityServerUrl"];
                options.Audience = "resource_discount";
                options.RequireHttpsMetadata = false;
            });

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();
            builder.Services.AddScoped<IDiscountService, DiscountService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}