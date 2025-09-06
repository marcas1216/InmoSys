using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using User.Infrastructure.Constants;
using User.Infrastructure.EF.Interfaces;

namespace User.Infrastructure.EF.Repositories
{
    public class JwtAuthRepository : IJwtAuthRepository
    {
        private readonly IKeyVaultRepository _keyVaultRepository;   

        public JwtAuthRepository(IKeyVaultRepository keyVaultRepository)
        {
            _keyVaultRepository = keyVaultRepository;
        }

        public  async Task<string> GenerateToken(string email, int userId, string module)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = await _keyVaultRepository.GetJwtSecretAsync(module);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Email, email),
                new Claim("UserId", userId.ToString())
            }),
                Expires = DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(JwtAuthConstants.TOKEN_EXPIRATION_MINUTES)
                ),
                Issuer = JwtAuthConstants.ISSUER,
                Audience = JwtAuthConstants.AUDIENCE,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
