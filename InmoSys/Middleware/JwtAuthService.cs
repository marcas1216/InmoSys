using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using User.Infrastructure.Constants;
using User.Infrastructure.EF.Interfaces;

namespace InmoSys.Middleware
{
    public static class JwtAuthService
    {       
        public static async Task<IServiceCollection> AddInmoJwtAuthentication(this IServiceCollection services,
            IKeyVaultRepository keyVaultRepository)
        {            
            var secret = await keyVaultRepository.GetJwtSecretAsync(JwtAuthConstants.JWT_MODULE);
            var issuer = JwtAuthConstants.ISSUER;
            var audience = JwtAuthConstants.AUDIENCE;
                        
            var key = new SymmetricSecurityKey(secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,

                    ValidateAudience = true,
                    ValidAudience = audience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(2)
                };
            });

            return services;
        }       
    }
}
