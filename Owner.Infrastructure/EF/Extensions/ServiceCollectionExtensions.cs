using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Owner.Infrastructure.EF.Context;
using Owner.Infrastructure.EF.Interfaces;

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

            return services;
        }
    }
}
