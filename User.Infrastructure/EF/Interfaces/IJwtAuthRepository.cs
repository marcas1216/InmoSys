
namespace User.Infrastructure.EF.Interfaces
{
    public interface IJwtAuthRepository
    {
        Task<string> GenerateToken(string email, int userId, string module);
    }
}
