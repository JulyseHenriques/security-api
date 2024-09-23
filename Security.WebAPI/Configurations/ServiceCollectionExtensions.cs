/*
using Security.Application.Commands.Handlers;
using Security.Application.Interfaces;
using Security.Application.Services;
using Security.Infrastructure.Data;
using Security.Infrastructure.Interfaces;
using Security.Infrastructure.Repositories;
*/

using Microsoft.EntityFrameworkCore;
using Security.Application.Commands.Handlers;
using Security.Application.Interfaces;
using Security.Application.Services;
using Security.Infrastructure.Data;
using Security.Infrastructure.Interfaces;
using Security.Infrastructure.Repositories;

namespace Security.WebAPI.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));
            services.AddControllers();

            // Add Swagger/OpenAPI for API documentation.
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}