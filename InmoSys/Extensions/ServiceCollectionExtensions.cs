using User.Infrastructure.EF.Interfaces;
using User.Infrastructure.EF.Repositories;

namespace InmoSys.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public  static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {           
            services.AddScoped<IUserRepository, UserRepository>();            
            services.AddScoped<IConnectionRepository, ConnectionRepository>();
            services.AddScoped<IKeyVaultRepository, KeyVaultRepository>();
            services.AddScoped<IJwtAuthRepository, JwtAuthRepository>();
            services.AddScoped<ILogsRepository, LogsRepository>();
            
            return services;
        }
    }
}
