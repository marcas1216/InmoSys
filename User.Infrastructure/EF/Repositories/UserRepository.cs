
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using User.Entities.Read;
using User.Entities.Write;
using User.Infrastructure.Constants;
using User.Infrastructure.EF.Context;
using User.Infrastructure.EF.Helpers;
using User.Infrastructure.EF.Interfaces;

namespace User.Infrastructure.EF.Repositories
{
    public class UserRepository : IUserRepository
    {        
        private readonly IConfiguration _config;
        private readonly InmoSysCoreContext _context;
        private readonly IJwtAuthRepository _jwtAuthRepository;
        private readonly ILogsRepository _logsRepository;

        public UserRepository(IConfiguration config
            ,InmoSysCoreContext context
            ,IJwtAuthRepository jwtAuthRepository
            ,ILogsRepository logsRepository
            )
        {
            (_config, _context, _jwtAuthRepository, _logsRepository) = (config, context, jwtAuthRepository, logsRepository);            
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

                string tokenString = await _jwtAuthRepository.GenerateToken(user.Email, user.Id, JwtAuthConstants.JWT_MODULE);

                var log = new AddLogs
                {
                    LModule = LogConstants.USER_MODULE,
                    LMethod = "LoginAsync",
                    LRequest = request,
                    LResponse = tokenString
                };

               _ = _logsRepository.AddLogAsync(log);

                return new LoginResult
                {
                    Success = true,
                    Message = "Login exitoso.",
                    Token = tokenString
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
