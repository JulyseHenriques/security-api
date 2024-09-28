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
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<SecurityContext>(options => options.UseNpgsql(connectionString));

            return services;
        }

        public static IServiceCollection ConfigureInterfaces(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            return services;
        }
    }
}