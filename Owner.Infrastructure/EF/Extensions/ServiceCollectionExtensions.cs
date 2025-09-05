using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Owner.Aplication.Interface;
using Owner.Infrastructure.BusinessRepositories.Read;
using Owner.Infrastructure.EF.Context;
using User.Infrastructure.EF.Interfaces;

namespace Owner.Infrastructure.EF.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOwnerContexts(this IServiceCollection services)
        {            
            services.AddDbContext<OwnerDbContext>((sp, options) =>
            {
                var connectionService = sp.GetRequiredService<IConnectionRepository>();
                string connectionString = connectionService.GetActiveConnectionAsync("OwnersServices").GetAwaiter().GetResult();
                options.UseSqlServer(connectionString);
            });

            services.AddScoped< IOwnerService, OwnerRepository >();

            return services;
        }
    }
}
