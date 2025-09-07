using Microsoft.Extensions.DependencyInjection;
using Properties.Infrastructure.EF.Context;
using User.Infrastructure.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using Properties.Infrastructure.BusinessRepositories.Read;
using Properties.Aplication.Interface.Write;
using Properties.Infrastructure.BusinessRepositories.Write;
using Properties.Aplication.Interface.Read;

namespace Properties.Infrastructure.EF.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPropertiesContexts(this IServiceCollection services)
        {
            services.AddDbContext<PropertiesDbContext>((sp, options) =>
            {
                var connectionService = sp.GetRequiredService<IConnectionRepository>();
                string? connectionString = connectionService.GetActiveConnectionAsync("PropertiesServices").GetAwaiter().GetResult();

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidOperationException("No se encontró una cadena de conexión válida para PropertiesServices.");
                }

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();
            services.AddScoped<IPropertyStateRepository, PropertyStateRepository>();
            services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
            services.AddScoped<IPropertyImageWriteRepository, PropertyImageWriteRepository>();
            services.AddScoped<IPropertyReadRepository, PropertyReadRepository>();
            services.AddScoped<IPropertyWriteRepository, PropertyWriteRepository>();

            return services;
        }
    }
}
