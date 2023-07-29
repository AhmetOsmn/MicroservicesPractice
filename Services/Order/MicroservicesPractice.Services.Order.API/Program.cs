
using MassTransit;
using MediatR;
using MicroservicesPractice.Services.Order.Application.Consumers;
using MicroservicesPractice.Services.Order.Infrastructure;
using MicroservicesPractice.Shared.Services.Abstract;
using MicroservicesPractice.Shared.Services.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace MicroservicesPractice.Services.Order.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

            builder.Services.AddDbContext<OrderDbContext>(opt =>
            {
                opt.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    cfg => cfg.MigrationsAssembly("MicroservicesPractice.Services.Order.Infrastructure"));
            });

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();

            builder.Services.AddMediatR(typeof(Application.Handlers.CreateOrderCommandHandler).Assembly);

            builder.Services.AddControllers(opt => opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy)));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<CreateOrderMessageCommandConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    // Default RMQ port: 5672
                    cfg.Host(builder.Configuration["RabbitMQUrl"], "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ReceiveEndpoint("create-order-service", e =>
                    {
                        e.ConfigureConsumer<CreateOrderMessageCommandConsumer>(context);
                    });
                });
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = builder.Configuration["IdentityServerUrl"];
                options.Audience = "resource_order";
                options.RequireHttpsMetadata = false;
            });

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