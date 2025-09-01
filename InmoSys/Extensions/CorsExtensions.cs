namespace InmoSys.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddInmoCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("InmoSysCors", policy =>
                {                   
                    policy
                        .WithOrigins("https://localhost:5001", "http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            return services;
        }
    }
}
