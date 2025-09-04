
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User.Entities.Read;
using User.Infrastructure.EF.Context;
using User.Infrastructure.EF.Helpers;
using User.Infrastructure.EF.Interfaces;

namespace User.Infrastructure.EF.Repositories
{
    public class UserRepository : IUserRepository
    {        
        private readonly IConfiguration _config;
        private readonly InmoSysCoreContext _context;
        
        public UserRepository(IConfiguration config
            ,InmoSysCoreContext context)

        {          
            _config = config;
            _context = context;               
        }

        public async Task<LoginResult> LoginAsync(UserLoginRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "El correo y la contraseña son obligatorios."
                    };
                }

                var user = await _context.Users
                          .AsNoTracking()
                          .FirstOrDefaultAsync(u => u.Email == request.Email);

                if (user == null)
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "El usuario no existe."
                    };
                }

                string hashPassword = SecurityHelper.Hash(request.Password);

                if (hashPassword != user.Password)
                {
                    return new LoginResult
                    {
                        Success = false,
                        Message = "La contraseña es incorrecta."
                    };
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config["Jwt:Secret"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserId", user.Id.ToString())
                     }),
                    Expires = DateTime.UtcNow.AddMinutes(
                        Convert.ToDouble(_config["Jwt:TokenExpirationMinutes"])
                    ),
                    Issuer = _config["Jwt:Issuer"],
                    Audience = _config["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new LoginResult
                {
                    Success = true,
                    Message = "Login exitoso.",
                    Token = tokenHandler.WriteToken(token)
                };
            }
            catch (Exception ex)
            {
                return new LoginResult
                {
                    Success = false,
                    Message = $"Error en el proceso de login: {ex.Message}",
                    Token = string.Empty
                };
            }            
        }

    }
}
