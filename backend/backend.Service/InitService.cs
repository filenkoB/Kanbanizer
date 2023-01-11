using backend.Service.Interfaces;
using backend.Service.Interfaces.Repository.Read;
using backend.Service.Repository.Read;
using backend.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace backend.Service
{
    public static class InitService
    {
        private static IConfiguration _configuration;
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration) {
            _configuration = configuration;
            
            AddJwt(services);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            AddServices(services);
            AddReadRepositories(services);
            AddWriteRepositories(services);

            return services;
        }

        private static IServiceCollection AddJwt(IServiceCollection services) {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = _configuration["Jwt:Issuer"],
                        ValidAudience = _configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                    };
                });
            return services;
        }

        private static IServiceCollection AddServices(IServiceCollection services) {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }

        private static IServiceCollection AddReadRepositories(IServiceCollection services) {
            services.AddScoped<IAuthReadRepository, AuthReadRepository>();
            services.AddScoped<IBoardReadRepository, BoardReadRepository>();
            services.AddScoped<IColumnsReadRepository, ColumnsReadRepository>();

            return services;
        }

        private static IServiceCollection AddWriteRepositories(IServiceCollection services) {
            return services;
        }
    }
}
